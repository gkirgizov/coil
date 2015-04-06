using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task7;

namespace Tests.Task7
{
    [TestClass]
    public class SetIntTest
    {
        private Set<int> tSet1;

        private Set<int> tSet2;

        [TestInitialize]
        public void Initialize()
        {
            tSet1 = new Set<int>() { 1, 3, 5 };
            tSet2 = new Set<int>() { 2, 4, 6 };
        }
        
        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, tSet1.Count);
        }

        [TestMethod]
        public void ContainsTest()
        {
            Assert.IsTrue(tSet1.Contains(1));
            Assert.IsTrue(tSet1.Contains(3));
            Assert.IsFalse(tSet1.Contains(2));
        }

        [TestMethod]
        public void AddEqual()
        {
            tSet1.Add(1);
            Assert.AreEqual(3, tSet1.Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            Assert.IsTrue(tSet1.Contains(3));
            tSet1.Remove(3);
            Assert.IsFalse(tSet1.Contains(3));
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            tSet1.IntersectWith(tSet2);
            Assert.AreEqual(0, tSet1.Count);
        }

        [TestMethod]
        public void UnionWithTest()
        {
            tSet1.UnionWith(tSet2);
            for (int i = 1; i <= 6; ++i)
            {
                Assert.IsTrue(tSet1.Contains(i));
            }
        }
    }
}
