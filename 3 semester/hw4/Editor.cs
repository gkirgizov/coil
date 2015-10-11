using System;
using System.Collections.Generic;
using System.Data;
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

                /// Т.о. кнопки меню меняют текущий режим курсора.
                newMenuTool.Click += new EventHandler(tool.ChangeTool);

                toolButtons[i] = newMenuTool;
                ++i;

                //почему-то не видит последний элемент меню
                tools.Items.Add(newMenuTool);
            }
            //this.toolsPanel.SuspendLayout();
            this.tools.SuspendLayout();
            this.SuspendLayout();

        }


        private void canvas_MouseDown(object sender, MouseEventArgs e) {
            var action = core.MouseDown(e.Location);
            if (action is VoidAction) {
            } else {
                history.Log(action);
            }
            core.Draw();
            this.Update();
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e) {
            var action = core.MouseUp(e.Location);
            if (action is VoidAction) {
            } else {
                history.Log(action);
            }
            core.Draw();
            this.Update();
        }

        private void undoButton_Click(object sender, EventArgs e) {
            history.Undo().Unexecute();
        }
        private void redoButton_Click(object sender, EventArgs e) {
            history.Redo().Execute();
        }

        private IGlyphLogic core;
        private List<ClickTool> availableTools;
        private ToolStripButton[] toolButtons;
        private ActionHistory history;


    }
}
