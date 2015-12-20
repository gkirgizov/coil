using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Defines UI and common logic
    /// (undo/redo, clicks, buttons etc.).
    /// </summary>
    public partial class Editor : Form {

        public Editor() {
            InitializeComponent();

            g = canvas.CreateGraphics();
            core = new GlyphLogic(canvas, g);
            history = new ActionHistory();

            /// По полученной информации создает кнопки выбора режима (или: tools)
            /// пр.: режим добавления линии (AddLineTool), режим добавления еще чего-то
            availableTools = core.AvailableTools;
            toolset = new ToolStripButton[availableTools.Count];
            int i = 0;
            foreach (var tool in availableTools) {
                var newMenuTool = new ToolStripButton(tool.Info);

                newMenuTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                newMenuTool.Name = tool.Info + "Button";
                newMenuTool.Size = new System.Drawing.Size(40, 22);

                newMenuTool.Click += new EventHandler(tool.ChangeTool);
                newMenuTool.Click += new EventHandler(this.tool_Clicked);

                toolset[i] = newMenuTool;
                ++i;

                tools.Items.Add(newMenuTool);
            }
            this.tools.SuspendLayout();
            this.SuspendLayout();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e) {
            var action = core.MouseDown(e);
            if (!(action is VoidAction)) {
                history.Log(action);
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) {
            var action = core.MouseMove(e);
            if (!(action is VoidAction)) {
                history.Log(action);
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e) {
            var action = core.MouseUp(e);
            if (!(action is VoidAction)) {
                history.Log(action);
            }
        }

        /// <summary>
        /// Occurs when tool button from toolset clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tool_Clicked(object sender, EventArgs e) {
            foreach (var tool in toolset) {
                tool.Checked = false;
            }
            var clickedTool = sender as ToolStripButton;
            clickedTool.Checked = true;
        }

        private void undoButton_Click(object sender, EventArgs e) {
            history.Undo().Unexecute();
            core.Draw(g);
            this.Update();
        }

        private void redoButton_Click(object sender, EventArgs e) {
            history.Redo().Execute();
            core.Draw(g);
            this.Update();
        }


        private IGlyphLogic core;
        private Graphics g;
        private ActionHistory history;

        private List<ClickTool> availableTools;
        private ToolStripButton[] toolset;
    }
}
