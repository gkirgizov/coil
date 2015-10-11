using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace hw4 {
    /// <summary>
    /// Defines specific logic.
    /// </summary>
    class GlyphLogic : IGlyphLogic {
        public GlyphLogic(Panel canvas) {
            this.canvas = canvas;
            g = this.canvas.CreateGraphics();
            g.Clear(Color.White);
            DrawProperties = new Pen(Color.Black);
            glyphs = new List<IGlyph>();

            var defaultTool = new ClickTool(this);
            AvailableTools = new List<ClickTool> {
                new RemoveTool(this),
                new AddLineTool(this),
                new MoveTool(this),
                defaultTool,

                new ClickTool(this) //почему-то не видит последний элемент
                };
        }

        
        public void Draw() {
            foreach (var glyph in glyphs) {
                glyph.Draw(g, DrawProperties);
            }
        }
        public Pen DrawProperties { get; set; }


        public IAction MouseDown(Point p) {
            return CurrentTool.MouseDown(p);
        }
        public IAction MouseUp(Point p) {
            return CurrentTool.MouseUp(p);
        }
        public IAction AddGlyph(IGlyph glyph) {
            glyphs.Add(glyph);
            return new AddAction(this, glyph);
        }
        // будет ли нормально удалять по ссылке? должен бы
        public IAction RemoveGlyph(IGlyph glyph) {
            glyphs.Remove(glyph);
            return new RemoveAction(this, glyph);
        }


        public ClickTool CurrentTool { get; set; }
        public List<ClickTool> AvailableTools { get; private set; }


        public IGlyph IntersectsWith(Point p) {
            foreach (var glyph in glyphs) {
                if (glyph.IsIntersects(p)) {
                    return glyph;
                }
            }
            return null;
        }


        private Panel canvas;
        private Graphics g;
        private List<IGlyph> glyphs;
    }
}
