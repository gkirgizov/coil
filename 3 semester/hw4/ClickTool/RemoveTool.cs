using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    public class RemoveTool : ClickTool {
        public RemoveTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
            this.Info = "Remove";
        }

        public override IAction MouseDown(MouseEventArgs e) {
            var glyph = parent.IntersectsWith(e.Location);
            if (glyph == null) {
                return new VoidAction();
            } else {
                return parent.RemoveGlyph(glyph);
            }
        }

        public override string Info { get; protected set; }

        private IGlyphLogic parent;
    }
}
