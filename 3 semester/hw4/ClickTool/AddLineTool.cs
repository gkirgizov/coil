using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    public class AddLineTool : ClickTool {
        public AddLineTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
            this.Info = "New Line";
        }

        public override IAction MouseDown(MouseEventArgs e) {
            startOfLine = e.Location;
            return new VoidAction();
        }

        public override IAction MouseUp(MouseEventArgs e) {
            return parent.AddGlyph(new Line(startOfLine, e.Location));
        }

        public override string Info { get; protected set; }

        private Point startOfLine;
        private IGlyphLogic parent;
    }
}
