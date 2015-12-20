using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Allows to create lines.
    /// </summary>
    public class AddLineTool : ClickTool {

        public AddLineTool(IGlyphLogic parent) {
            this.parent = parent;
            this.Info = "New Line";
            this.isAddingStarted = false;
        }

        public override IAction MouseDown(MouseEventArgs e) {
            addedLine = new Line(e.Location, e.Location);
            isAddingStarted = true;
            addedLine.Selected = Line.LineEnds.end;
            return parent.AddGlyph(addedLine);
        }

        public override IAction MouseMove(MouseEventArgs e) {
            if (isAddingStarted) {
                addedLine.Move(e.Location);
                parent.Draw();
            }
            return defaultReturning;
        }

        public override IAction MouseUp(MouseEventArgs e) {
            addedLine.MouseUp(e);
            addedLine = null;
            isAddingStarted = false;
            return defaultReturning;
        }

        public override string Info { get; protected set; }

        private bool isAddingStarted;
        private Line addedLine;
    }
}
