using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Represents simple line.
    /// Allows to move itself.
    /// </summary>
    public class Line : IGlyph {

        public Line(Point start, Point end) {
            this.Start = start;
            this.End = end;

            Selected = LineEnds.nothing;
        }

        public void Draw(Graphics g, Pen pen) {
            pen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            g.DrawLine(pen, Start, End);
        }

        public bool IsIntersects(Point p) {
            
            /// Calc distance between point p and start of the line.
            if (calcSqrDist(p, Start) < sqrIntersectionRange) {
                Selected = LineEnds.start;
                return true;
            }

            /// Calc distance between point p and end of the line.
            if (calcSqrDist(End, p) < sqrIntersectionRange) {
                Selected = LineEnds.end;
                return true;
            }

            /// Calc distance between point p and the line itself.
            var dx = End.X - Start.X;
            var dy = End.Y - Start.Y;
            var sqrLength = dx * dx + dy * dy;
            var dVector = new Point(dx, dy);

            double vectorMult = -dVector.Y * p.X + dVector.X * p.Y +
                (Start.X * End.Y - End.X * Start.Y);
            var sqrDist = vectorMult * vectorMult / sqrLength;
            return sqrDist < sqrIntersectionRange;
        }


        public IAction MouseDown(MouseEventArgs e) => new VoidAction();

        public IAction MouseMove(MouseEventArgs e) => new VoidAction();

        public IAction MouseUp(MouseEventArgs e) {
            Selected = LineEnds.nothing;
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
            }
            return new VoidAction();
        }


        public enum LineEnds { start, end, nothing }

        public LineEnds Selected { get; set; }
        public Point Start { get; private set; }
        public Point End { get; private set; }


        private double calcSqrDist(Point p1, Point p2) {
            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return dx * dx + dy * dy;
        }

        private const int sqrIntersectionRange = 25;
    }
}
