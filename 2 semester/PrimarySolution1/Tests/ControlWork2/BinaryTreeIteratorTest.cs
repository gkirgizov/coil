using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ControlWork2;

namespace Tests.ControlWork2
{
    [TestClass]
    public class BinaryTreeIteratorTest
    {
        private Iterator iterator;

        [TestInitialize]
        public void Init()
        {
            var tree = new BinTree();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            iterator = new Iterator(tree);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NextIfTreeIsNull()
        {
            iterator =  new Iterator(null);
            iterator.Next();
        }

        [TestMethod]
        public void NextTest()
        {
            Assert.AreEqual(1, iterator.Next());
            Assert.AreEqual(2, iterator.Next());
            Assert.AreEqual(3, iterator.Next());
        }
    }
}
