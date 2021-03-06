﻿using System.Collections.Generic;
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
            iterator = tree.GetEnumerator();

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
        public void TestEmptyTree() {
            tree = new BinarySearchTree();
            iterator = tree.GetEnumerator();
            Assert.IsFalse(iterator.MoveNext());
        }

        [TestMethod]
        public void TestReset() {
            var first = iterator.Current;
            iterator.MoveNext();
            iterator.Reset();
            Assert.AreEqual(first, iterator.Current);
        }

        [TestMethod]
        public void TestNextBreadthFirst() {
            int i = 0;
            foreach (var value in tree) {
                Assert.AreEqual(breadthFirstOrderList[i], value);
                ++i;
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
            int i = 0;
            foreach (var value in tree) {
                Assert.AreEqual(depthFirstOrderList[i], value);
                ++i;
            }
        }

        BinarySearchTree tree;
        IEnumerator<int> iterator;
        List<int> breadthFirstOrderList;
    }
}
