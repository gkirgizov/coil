using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Provides common interface for using different objects within this editor.
    /// </summary>
    public interface IGlyph {
        /// <summary>
        /// Draws itself.
        /// </summary>
        /// <param name="g">Provides graphic interface.</param>
        /// <param name="pen">Provides drawing parameters.</param>
        void Draw(Graphics g, Pen pen);

        bool IsIntersects(Point p);

        IAction MouseDown(MouseEventArgs e);
        IAction MouseUp(MouseEventArgs e);
        IAction Move(Point p);
    }
}
