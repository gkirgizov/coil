using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    public class Line : IGlyph {
        public Line(Point start, Point end) {
            this.Start = start;
            this.End = end;

            var dx = end.X - start.X;
            var dy = end.Y - start.Y;
            this.sqrLength = dx * dx + dy * dy;
            this.dVector = new Point(dx, dy);

            Selected = LineEnds.nothing;
        }

        public void Draw(Graphics g, Pen pen) {
            pen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            g.DrawLine(pen, Start, End);
        }
        public bool IsIntersects(Point p) {
            double sqrDist;

            /// Calc distance between point p and start of the line.
            var dSx = p.X - Start.X;
            var dSy = p.Y - Start.Y;
            sqrDist = dSx * dSx + dSy * dSy;
            if (sqrDist < sqrIntersectionRange) {
                Selected = LineEnds.start;
                return true;
            }

            /// Calc distance between point p and end of the line.
            var dEx = End.X - p.X;
            var dEy = End.Y - p.Y;
            sqrDist = dEx * dEx + dEy * dEy;
            if (sqrDist < sqrIntersectionRange) {
                Selected = LineEnds.end;
                return true;
            }

            /// Calc distance between point p and the line itself.
            double vectorMult = -dVector.Y * p.X + dVector.X * p.Y +
                (Start.X * End.Y - End.X * Start.Y);
            sqrDist = vectorMult * vectorMult / sqrLength;
            return sqrDist < sqrIntersectionRange;
        }

        public IAction MouseDown(MouseEventArgs e) {
            return new VoidAction();
        }
        public IAction MouseUp(MouseEventArgs e) {
            return new VoidAction();
        }
        public IAction Move(Point p) {
            Point oldP;
            if (Selected == LineEnds.start) {
                oldP = Start;
                Start = p;
            } else if (Selected == LineEnds.end) {
                oldP = End;
                End = p;
            } else {
                return new VoidAction();
            }
            var wasSelected = Selected;
            Selected = LineEnds.nothing;
            return new MoveLineAction(this, oldP, p, wasSelected);
        }


        public enum LineEnds { start, end, nothing }
        public LineEnds Selected { get; set; }
        public Point Start { get; private set; }
        public Point End { get; private set; }

        private Point dVector;
        private int sqrLength;
        private const int sqrIntersectionRange = 25;
    }
}
