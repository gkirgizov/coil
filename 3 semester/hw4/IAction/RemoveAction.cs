
namespace hw4 {
    public class RemoveAction : IAction {
        public RemoveAction(GlyphLogic parent, IGlyph glyph) {
            this.parent = parent;
            this.glyph = glyph;
        }

        public void Execute() {
            parent.RemoveGlyph(glyph);
        }
        public void Unexecute() {
            parent.AddGlyph(glyph);
        }

        private IGlyph glyph;
        private GlyphLogic parent;
    }
}
