using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw1;

namespace testHW1 {
    [TestClass]
    public class BSTIteratorTests {

        [TestInitialize]
        public void Init() {
            tree = new BinarySearchTree();
            tree.Add(8);
            tree.Add(2);
            tree.Add(32);
            tree.Add(1);
            tree.Add(4);
            tree.Add(16);
            tree.Add(64);
            iterator = tree.ReturnIterator();

            breadthFirstOrderList = new List<int>();
            breadthFirstOrderList.Add(8);
            breadthFirstOrderList.Add(2);
            breadthFirstOrderList.Add(32);
            breadthFirstOrderList.Add(1);
            breadthFirstOrderList.Add(4);
            breadthFirstOrderList.Add(16);
            breadthFirstOrderList.Add(64);
        }

        [TestMethod]
        public void TestIsEmpty() {
            tree = new BinarySearchTree();
            iterator = tree.ReturnIterator();
            Assert.IsTrue(iterator.IsEmpty());
        }

        [TestMethod]
        public void TestReset() {
            var first = iterator.Next();
            iterator.Reset();
            Assert.AreEqual(first, iterator.Next());
        }

        [TestMethod]
        public void TestNextBreadthFirst() {
            for (int i = 0; !iterator.IsEmpty(); ++i) {
                Assert.AreEqual(breadthFirstOrderList[i], iterator.Next());
                Assert.IsFalse(i > 6);
            }
        }

        [TestMethod]
        public void TestNextDepthFirst() {
            var depthFirstOrderList = new List<int>();
            depthFirstOrderList.Add(8);
            depthFirstOrderList.Add(2);
            depthFirstOrderList.Add(1);
            depthFirstOrderList.Add(4);
            depthFirstOrderList.Add(32);
            depthFirstOrderList.Add(16);
            depthFirstOrderList.Add(64);

            tree.Mode = BSTIterator<int>.IteratorMode.DepthFirst;
            iterator = tree.ReturnIterator();
            for (int i = 0; !iterator.IsEmpty(); ++i) {
                Assert.AreEqual(depthFirstOrderList[i], iterator.Next());
                Assert.IsFalse(i > 6);
            }
        }

        [TestMethod]
        public void TestRemove() {
            var removingData = iterator.Current;
            Assert.IsTrue(iterator.Remove());
            for (; !iterator.IsEmpty(); iterator.Remove()) {
                Assert.IsFalse(tree.Contains(removingData));
                removingData = iterator.Current;
            }
        }

        BinarySearchTree tree;
        IIterator<int> iterator;
        List<int> breadthFirstOrderList;
    }
}
