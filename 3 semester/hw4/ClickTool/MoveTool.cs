using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Allows to move glyphs due to IGlyph.Move() method.
    /// </summary>
    public class MoveTool : ClickTool {

        public MoveTool(IGlyphLogic parent) {
            this.parent = parent;
            this.Info = "Move";
        }

        public override IAction MouseDown(MouseEventArgs e) {
            selected = parent.IntersectsWith(e.Location);
            if (selected != null) {
                this.firstP = e.Location;
            }
            return defaultReturning;
        }

        public override IAction MouseMove(MouseEventArgs e) {
            if (selected != null) {
                selected.Move(e.Location);
                parent.Draw();
            }
            return defaultReturning;
        }

        public override IAction MouseUp(MouseEventArgs e) {
            if (selected == null) {
                return defaultReturning;
            }
            selected.Move(e.Location);
            selected.MouseUp(e);

            var returning = new MoveAction(selected, firstP, e.Location);
            selected = null;
            return returning;
        }

        public override string Info { get; protected set; }

        private IGlyph selected;
        private Point firstP;
    }
}
