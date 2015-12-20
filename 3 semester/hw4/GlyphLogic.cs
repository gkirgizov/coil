using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace hw4 {
    public class GlyphLogic : IGlyphLogic {

        public GlyphLogic(Panel canvas, Graphics g) {
            this.g = g;
            this.canvas = canvas;
            DrawProperties = new Pen(Color.Black);
            glyphs = new List<IGlyph>();

            CurrentTool = new VoidTool(this);
            AvailableTools = new List<ClickTool> {
                new RemoveTool(this),
                new AddLineTool(this),
                new MoveTool(this),

                CurrentTool //почему-то не видит последний элемент
                };
        }

        public void Draw() {
            g.Clear(Color.WhiteSmoke);

            foreach (var glyph in glyphs) {
                glyph.Draw(g, DrawProperties);
            }
        }
        public void Draw(Graphics g) {
            this.g = g;
            Draw();
        }

        public Pen DrawProperties { get; set; }


        public IAction MouseDown(MouseEventArgs e) => CurrentTool.MouseDown(e);

        public IAction MouseMove(MouseEventArgs e) => CurrentTool.MouseMove(e);

        public IAction MouseUp(MouseEventArgs e) => CurrentTool.MouseUp(e);


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

        private Graphics g;
        private Panel canvas;
        private List<IGlyph> glyphs;
    }
}
