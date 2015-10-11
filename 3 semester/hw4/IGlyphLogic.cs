using System.Collections.Generic;
using System.Drawing;

namespace hw4 {
    interface IGlyphLogic {

        void Draw();
        Pen DrawProperties { get; }

        IAction MouseDown(Point location);
        IAction MouseUp(Point location);
        IAction AddGlyph(IGlyph glyph);
        IAction RemoveGlyph(IGlyph glyph);

        IGlyph IntersectsWith(Point coord);

        List<ClickTool> AvailableTools { get; }
        ClickTool CurrentTool { get; set; }
    }
}