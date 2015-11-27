using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw4;

namespace testHW4 {
    [TestClass]
    public class AppTests {
        [TestInitialize]
        public void Init() {
            canvas = new Panel();
            log = new ActionHistory();
            core = new GlyphLogic(canvas, canvas.CreateGraphics());
            tools = core.AvailableTools;

            p = new Point(0, 0);
            gl = new Line(p, p);
        }

        // GlyphLogic Tests

        [TestMethod]
        public void IntersectsWith() {
            var p = new Point(0, 0);
            var gl = new Line(p, p);
            core.AddGlyph(gl);
            Assert.IsTrue(core.IntersectsWith(p) == gl);
        }

        [TestMethod]
        public void RemoveGlyph() {
            core.AddGlyph(gl);
            Assert.IsTrue(core.IntersectsWith(p) == gl);

            core.RemoveGlyph(gl);
            Assert.IsTrue(core.IntersectsWith(p) == null);
        }

        // Actions Tests

        [TestMethod]
        public void AddLineAction() {
            var action = new AddAction(core, gl);
            action.Execute();
            Assert.IsTrue(core.IntersectsWith(p) == gl);

            action.Unexecute();
            Assert.IsTrue(core.IntersectsWith(p) == null);
        }

        [TestMethod]
        public void RemoveGlyphAction() {
            core.AddGlyph(gl);

            var action = new RemoveAction(core, gl);
            action.Execute();
            Assert.IsTrue(core.IntersectsWith(p) == null);

            action.Unexecute();
            Assert.IsTrue(core.IntersectsWith(p) == gl);
        }

        [TestMethod]
        public void MoveGlyphAction() {
            core.AddGlyph(gl);
            var p2 = new Point(100, 100);
            Assert.IsTrue(core.IntersectsWith(p2) == null);

            var action = new MoveAction(gl, p, p2);
            action.Execute();
            Assert.IsTrue(core.IntersectsWith(p2) == gl);

            action.Unexecute();
            Assert.IsTrue(core.IntersectsWith(p2) == null);
            Assert.IsTrue(core.IntersectsWith(p) == gl);
        }

        // ActionHistory Tests

        [TestMethod]
        public void UndoActionHistory() {
            var action = new AddAction(core, gl);
            action.Execute();

            log.Log(action);
            log.Undo().Unexecute();
            Assert.IsFalse(core.IntersectsWith(p) == gl);
        }

        [TestMethod]
        public void RedoActionHistory() {
            var action = new AddAction(core, gl);
            action.Execute();

            log.Log(action);
            log.Undo().Unexecute();
            log.Redo().Execute();
            Assert.IsTrue(core.IntersectsWith(p) == gl);
        }

        [TestMethod]
        public void EmptyActionHistoryUndo() {
            log.Undo().Unexecute();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RedoWhenNothingToRedo() {
            core.AddGlyph(gl);

            var action = new RemoveAction(core, gl);
            log.Log(action);
            log.Redo().Execute();
            Assert.IsTrue(core.IntersectsWith(p) == gl);
        }

        enum toolId { Remove, AddLine, Move, Void };

        private Point p;
        private Line gl;

        private Panel canvas;
        private GlyphLogic core;
        private List<ClickTool> tools;
        private ActionHistory log;
    }
}
