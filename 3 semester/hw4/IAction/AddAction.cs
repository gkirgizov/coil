
namespace hw4 {
    public class AddAction : IAction {
        public AddAction(GlyphLogic parent, IGlyph glyph) {
            this.parent = parent;
            this.glyph = glyph;
        }

        public void Execute() {
            parent.AddGlyph(glyph);
        }

        public void Unexecute() {
            parent.RemoveGlyph(glyph);
        }

        private IGlyph glyph;
        private GlyphLogic parent;
    }
}

