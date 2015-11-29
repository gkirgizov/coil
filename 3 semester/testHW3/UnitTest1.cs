using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using hw3;

namespace UnitTestProject1 {
    [TestClass]
    public class RoboExistenceTests {

        private List<List<int>> links;
        private List<bool> robots;
        private Graph<bool> g;
        private RoboExistence app;

        [TestInitialize]
        public void Init() {
            robots = new List<bool>(4) { true, true, false, false};
            links = new List<List<int>>() {
                new List<int>() { 1 },
                new List<int>() { 0, 2 },
                new List<int>() { 1, 3 }
            };
            // there is a graph: (R)--(R)--()--()
            g = new Graph<bool>(robots, links);
            app = new RoboExistence(g);
        }

        [TestMethod]
        public void BipartedGraphNotSuicideRobots() {
            Assert.IsFalse(app.AreRobotsDie());
        }

        [TestMethod]
        public void BipartedGraphSuicideRobots() {
            g.AddItem(true);
            g.AddItem(true);
            g.AddEdge(3, 4);
            g.AddEdge(5, 4);
            // there is a graph: (R)--(R)--()--()--(R)--(R)
            Assert.IsTrue(app.AreRobotsDie());
        }

        [TestMethod]
        public void MonopartedGraphSuicideRobots() {
            g.AddEdge(1, 3);
            Assert.IsTrue(app.AreRobotsDie());
        }

        [TestMethod]
        public void MonopartedGraphNotSuicideRobots() {
            g.AddEdge(1, 3);
            robots[3] = true;
            // there is a graph: (R)--(R)--()--(R)
            g = new Graph<bool>(robots, links);
            app = new RoboExistence(g);
            Assert.IsFalse(app.AreRobotsDie());
        }
    }
}
