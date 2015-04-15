using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace Tests.Task2
{
    /// <summary>
    /// Tests to hash table with string type of the data
    /// </summary>
    [TestClass]
    public class HashTableStringTest
    {
        private HashTable<string> htable;

        [TestInitialize]
        public void Initialize()
        {
            htable = new HashTable<string>(10, HashFunctions.UniversalHashFunction);
        }

        [TestMethod]
        public void HashFunctionsChangelingTest()
        {
            htable.HashFunction = HashFunctions.StringHashFunction1;
            Assert.AreEqual(htable.HashFunction, HashFunctions.StringHashFunction1);
        }

        [TestMethod]
        public void HashFunctionsChangelingDataValidTest()
        {
            htable.Add("0");
            htable.Add("1");
            htable.Add("3");
            htable.HashFunction = HashFunctions.StringHashFunction1;
            Assert.IsTrue(htable.Search("0"));
            Assert.IsTrue(htable.Search("1"));
            Assert.IsTrue(htable.Search("3"));
        }

        [TestMethod]
        public void AddSearchTest()
        {
            htable.Add("0");
            htable.Add("1");
            htable.Add("2");
            htable.Add("3");
            htable.Add("4");
            htable.Add("5");
            htable.Add("6");
            htable.Add("7");
            Assert.IsTrue(htable.Search("3"));
            Assert.IsFalse(htable.Search("8"));
        }

        [TestMethod]
        public void DeleteTest()
        {
            htable.Add("0");
            htable.Add("1");
            htable.Add("2");
            htable.Delete("1");
            Assert.IsFalse(htable.Search("1"));
        }
    }
}
