using System;
using System.Collections.Generic;
using System.Drawing;

namespace hw4 {
    class Line : IGlyph {
        public Line(Point begin, Point end) {
            this.begin = begin;
            this.end = end;
            this.IsActive = false;
            endsSize = 2;
        }

        public void Draw(Graphics g, Pen pen) {
            g.DrawLine(pen, begin, end);

            /// Draw circles on the ends of line.
            int halfSize = -endsSize / 2;
            Point b = new Point(halfSize + begin.X, halfSize + begin.Y);
            Point e = new Point(halfSize + end.X, halfSize + end.Y);
            var size = new Size(endsSize, endsSize);
            var bCircle = new Rectangle(b, size);
            var eCircle = new Rectangle(e, size);
            g.DrawEllipse(pen, bCircle);
            g.DrawEllipse(pen, eCircle);
        }

        public bool IsIntersects(Point p) {
            throw new NotImplementedException();
        }



        public IAction Clicked(Point p) {
            if (!IsActive) {
                IsActive = true;
            }
            return new VoidAction();
        }

        public IAction Move(Point p) {
            throw new NotImplementedException();
        }

        private bool IsActive;
        private Point begin;
        private Point end;
        private int endsSize;
    }
}
