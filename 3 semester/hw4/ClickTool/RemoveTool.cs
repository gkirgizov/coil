using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Allows to remove glyphs.
    /// </summary>
    public class RemoveTool : ClickTool {

        public RemoveTool(IGlyphLogic parent) {
            this.parent = parent;
            this.Info = "Remove";
        }

        public override IAction MouseDown(MouseEventArgs e) {
            var glyph = parent.IntersectsWith(e.Location);
            if (glyph == null) {
                return defaultReturning;
            }

            var returning = parent.RemoveGlyph(glyph);
            parent.Draw();
            return returning;
        }

        public override string Info { get; protected set; }
    }
}
