using System.Drawing;

namespace hw4 {
    class RemoveTool : ClickTool {
        public RemoveTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
        }

        public override IAction MouseDown(Point p) {
            var maybeGlyph = parent.IntersectsWith(p);
            if (maybeGlyph == null) {
                return new VoidAction();
            } else {
                return parent.RemoveGlyph(maybeGlyph);
            }
        }

        private IGlyphLogic parent;
    }
}
