using System.Drawing;

namespace hw4 {
    class AddLineTool : ClickTool {
        public AddLineTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
        }

        public override IAction MouseDown(Point p) {
            beginOfLine = p;
            return new VoidAction();
        }

        public override IAction MouseUp(Point p) {
            return parent.AddGlyph(new Line(beginOfLine, p));
        }

        private Point beginOfLine;
        private IGlyphLogic parent;
    }
}
