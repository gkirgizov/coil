using System.Drawing;

namespace hw4 {
    /// <summary>
    /// Allows to cancel moving of the glyph
    /// and cancel cancelling of it.
    /// </summary>
    public class MoveAction : IAction {
        public MoveAction(IGlyph glyph, Point oldP, Point newP) {
            this.glyph = glyph;
            this.oldP = oldP;
            this.newP = newP;
        }

        public void Execute() {
            glyph.IsIntersects(oldP);
            glyph.Move(newP);
        }

        public void Unexecute() {
            glyph.IsIntersects(newP);
            glyph.Move(oldP);
        }

        private IGlyph glyph;
        private Point oldP;
        private Point newP;
    }
}
