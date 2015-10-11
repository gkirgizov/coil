using System.Drawing;
using System.Collections.Generic;

namespace hw4 {
    class MoveTool : ClickTool {
        public MoveTool(IGlyphLogic parent) : base(parent) {
            this.parent = parent;
            this.active = null;
        }

        public override IAction MouseDown(Point p) {
            active = parent.IntersectsWith(p);
            return new VoidAction();
        }
        public override IAction MouseUp(Point p) {
            if (active == null) {
                return new VoidAction();
            } else {
                return active.Move(p);
            }
        }

        private IGlyph active;
        private IGlyphLogic parent;
    }
}
