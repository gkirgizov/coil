using System.Drawing;

namespace hw4 {
    interface IGlyph {
        void Draw(Graphics g, Pen pen);

        bool IsIntersects(Point p);

        IAction Clicked(Point p);

        IAction Move(Point p);
    }
}
