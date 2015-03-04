using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Task2.Tests
{
    /// <summary>
    /// Test class for linked list contains int
    /// </summary>
    [TestClass]
    public class LinkedListTest
    {
        private static LinkedList<int> tList;

        [TestInitialize]
        public void Initialize()
        {
            tList = new LinkedList<int>();
        }

        [TestMethod]
        public void AddGetHeadTwoItemsTest()
        {
            tList.Add(1);
            tList.Add(2);
            Assert.AreEqual(tList.Get(0), 1);
            Assert.AreEqual(tList.Get(1), 2);
        }

        [TestMethod]
        public void AddGetTailTwoItemsTest()
        {
            tList.Add(1);
            tList.Add(2);
            tList.Add(3);
            int last = tList.Size - 1;
            Assert.AreEqual(tList.Get(last), 3);
            Assert.AreEqual(tList.Get(last - 1), 2);
        }
        [TestMethod]
        public void GetNullTest()
        {
            Assert.AreEqual(tList.Get(0), default(int));
            tList.Add(1);
            Assert.AreEqual(tList.Get(1), default(int));
        }

        [TestMethod]
        public void SearchTest()
        {
            tList.Add(1);
            tList.Add(2);
            tList.Add(3);
            Assert.IsFalse(!tList.Search(2));
            Assert.IsFalse(tList.Search(4));
        }

        [TestMethod]
        public void DeleteTest()
        {
            tList.Add(1);
            tList.Add(2);
            tList.Delete(2);
            Assert.AreEqual(tList.Get(1), default(int));
            tList.Delete(2);
            Assert.AreEqual(tList.Get(0), 1);
        }
    }
}
