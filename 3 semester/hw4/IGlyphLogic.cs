using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace hw4 {
    /// <summary>
    /// Defines specific for software logic and behaviour,
    /// e.g.: drawing, interaction with glyphs, mouse events handling, available tools.
    /// </summary>
    public interface IGlyphLogic {

        /// <summary>
        /// Draws all glyphs.
        /// </summary>
        /// <param name="g"></param>
        void Draw();
        void Draw(Graphics g);
        
        /// <summary>
        /// Defines drawing properties.
        /// </summary>
        Pen DrawProperties { get; }

        
        /// <summary>
        /// MouseDown event handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseDown(MouseEventArgs e);

        /// <summary>
        /// MouseMove event handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseMove(MouseEventArgs e);
        
        /// <summary>
        /// MouseUp evnt handler.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        IAction MouseUp(MouseEventArgs e);
        
        /// <summary>
        /// Add new glyph.
        /// </summary>
        /// <param name="glyph"></param>
        /// <returns></returns>
        IAction AddGlyph(IGlyph glyph);
        
        /// <summary>
        /// Remove glyph.
        /// </summary>
        /// <param name="glyph"></param>
        /// <returns></returns>
        IAction RemoveGlyph(IGlyph glyph);

        
        /// <summary>
        /// Returns glyph intersecting with specified point
        /// if it exists, null otherwise.
        /// </summary>
        /// <param name="coord"></param>
        /// <returns></returns>
        IGlyph IntersectsWith(Point coord);

        /// <summary>
        /// Provides list of available tools for editor.
        /// </summary>
        List<ClickTool> AvailableTools { get; }

        ClickTool CurrentTool { get; set; }
    }
}