using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4 {
    class RemoveAction : IAction {
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
