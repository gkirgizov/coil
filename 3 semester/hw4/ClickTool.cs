using System.Drawing;

namespace hw4 {
    /// <summary>
    /// Incapsulates specific for IGlyphLogic behavior.
    /// </summary>
    class ClickTool {
        public ClickTool(IGlyphLogic parent) {
            this.parent = parent;
        }

        public virtual IAction MouseDown(Point p) {
            return new VoidAction();
        }
        public virtual IAction MouseUp(Point p) {
            return new VoidAction();
        }


        public virtual string Info {
            get {
                return this.GetType().Name;
            }
        }

        public void ChangeTool(object sender, System.EventArgs args) {
            parent.CurrentTool = this;
        }

        private IGlyphLogic parent;
    }
}
