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

            core = new GlyphLogic(canvas);
            g = canvas.CreateGraphics();
            history = new ActionHistory();

            /// По полученной информации создает кнопки выбора режима (или: tools)
            /// пр.: режим добавления линии (AddLineTool), режим добавления еще чего-то
            availableTools = core.AvailableTools;
            toolButtons = new ToolStripButton[availableTools.Count];
            int i = 0;
            foreach (var tool in availableTools) {
                var newMenuTool = new ToolStripButton(tool.Info);

                this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                this.undoButton.Name = tool.Info + "Button";
                this.undoButton.Size = new System.Drawing.Size(40, 22);

                newMenuTool.Click += new EventHandler(tool.ChangeTool);

                toolButtons[i] = newMenuTool;
                ++i;

                tools.Items.Add(newMenuTool);
            }
            this.tools.SuspendLayout();
            this.SuspendLayout();
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e) {
            var action = core.MouseDown(e);
            if (action is VoidAction) {
            } else {
                history.Log(action);
            }
            core.Draw(g);
            this.Update();
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e) {
            var action = core.MouseUp(e);
            if (action is VoidAction) {
            } else {
                history.Log(action);
            }
            core.Draw(g);
            this.Update();
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
        private ToolStripButton[] toolButtons;

        private void canvas_Resize(object sender, EventArgs e) {
            g = canvas.CreateGraphics();
        }
    }
}
