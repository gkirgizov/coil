using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace hw4 {
    /// <summary>
    /// Defines specific logic.
    /// </summary>
    public class GlyphLogic : IGlyphLogic {
        public GlyphLogic(Panel canvas) {
            this.canvas = canvas;
            DrawProperties = new Pen(Color.Black);
            glyphs = new List<IGlyph>();

            CurrentTool = new ClickTool(this);
            AvailableTools = new List<ClickTool> {
                new RemoveTool(this),
                new AddLineTool(this),
                new MoveTool(this),
                CurrentTool,

                new ClickTool(this) //почему-то не видит последний элемент
                };
        }

        public void Draw(Graphics g) {
            g.Clear(Color.WhiteSmoke);

            foreach (var glyph in glyphs) {
                glyph.Draw(g, DrawProperties);
            }
        }
        public Pen DrawProperties { get; set; }

        public IAction MouseDown(MouseEventArgs e) {
            return CurrentTool.MouseDown(e);
        }
        public IAction MouseUp(MouseEventArgs e) {
            return CurrentTool.MouseUp(e);
        }
        public IAction AddGlyph(IGlyph glyph) {
            glyphs.Add(glyph);
            return new AddAction(this, glyph);
        }
        public IAction RemoveGlyph(IGlyph glyph) {
            glyphs.Remove(glyph);
            return new RemoveAction(this, glyph);
        }

        public IGlyph IntersectsWith(Point p) {
            foreach (var glyph in glyphs) {
                if (glyph.IsIntersects(p)) {
                    return glyph;
                }
            }
            return null;
        }

        public ClickTool CurrentTool { get; set; }
        public List<ClickTool> AvailableTools { get; private set; }


        private Panel canvas;
        private List<IGlyph> glyphs;
    }
}
