using System.Windows.Forms;

namespace hw4 {
    public class MoveTool : ClickTool {
        public MoveTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
            this.selected = null;
            this.Info = "Move";
        }

        public override IAction MouseDown(MouseEventArgs e) {
            selected = parent.IntersectsWith(e.Location);
            return new VoidAction();
        }
        public override IAction MouseUp(MouseEventArgs e) {
            if (selected == null) {
                return new VoidAction();
            } else {
                return selected.Move(e.Location);
            }
        }

        public override string Info { get; protected set; }

        private IGlyph selected;
        private IGlyphLogic parent;
    }
}
