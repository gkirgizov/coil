using System.Drawing;

namespace hw4 {
    public class MoveLineAction : IAction {
        public MoveLineAction(Line line, Point oldP, Point newP, Line.LineEnds moved) {
            this.line = line;
            this.oldP = oldP;
            this.newP = newP;
            this.moved = moved;
        }

        public void Execute() {
            line.Selected = moved;
            line.Move(newP);
        }
        public void Unexecute() {
            line.Selected = moved;
            line.Move(oldP);
        }

        private Line line;
        private Point oldP;
        private Point newP;
        private Line.LineEnds moved;
    }
}
