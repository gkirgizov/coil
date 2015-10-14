using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Incapsulates specific for IGlyphLogic behavior.
    /// </summary>
    public class ClickTool {
        public ClickTool(IGlyphLogic parent) {
            this.parent = parent;
            //this.Info = this.GetType().Name;
            this.Info = "";
        }

        public virtual IAction MouseDown(MouseEventArgs e) {
            return new VoidAction();
        }
        public virtual IAction MouseUp(MouseEventArgs e) {
            return new VoidAction();
        }

        /// <summary>
        /// Returns short info about the tool.
        /// </summary>
        public virtual string Info { get; protected set; }

        public void ChangeTool(object sender, System.EventArgs args) {
            parent.CurrentTool = this;
        }

        private IGlyphLogic parent;
    }
}
