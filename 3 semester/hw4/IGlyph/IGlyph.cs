using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Provides common interface for using different objects within this IGlyphLogic.
    /// </summary>
    public interface IGlyph {

        /// <summary>
        /// Draws itself.
        /// </summary>
        /// <param name="g">Provides graphic interface.</param>
        /// <param name="pen">Provides drawing parameters.</param>
        void Draw(Graphics g, Pen pen);

        /// <summary>
        /// Checks if the point belongs to the glyph.
        /// </summary>
        /// <param name="p">Checking point.</param>
        /// <returns>True if belongs.</returns>
        bool IsIntersects(Point p);

        /// <summary>
        /// MouseDown handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseDown(MouseEventArgs e);

        /// <summary>
        /// MouseMove handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseMove(MouseEventArgs e);

        /// <summary>
        /// MouseUp handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseUp(MouseEventArgs e);

        /// <summary>
        /// Somehow moves glyph to the specified point.
        /// This "somehow" is defines by the concrete glyphs.
        /// </summary>
        /// <param name="p">Specified point.</param>
        /// <returns></returns>
        IAction Move(Point p);
    }
}
