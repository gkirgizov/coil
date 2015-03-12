using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Tests.Task4
{
    /// <summary>
    /// Tests for UniqueList with int data
    /// </summary>
    [TestClass]
    public class UniqueListTest
    {
        public UniqueList<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new UniqueList<int>();
            list.Add(10);
            list.Add(17);
        }

        [TestMethod]
        [ExpectedException(typeof(AddExistingItemException))]
        public void AddExistingItemTest()
        {
            list.Add(10);
        }

        [TestMethod]
        [ExpectedException(typeof(DeleteNonexistentItemException))]
        public void DeleteNonexistentData()
        {
            list.Delete(8);
        }
    }
}
