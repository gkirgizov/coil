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
            htable = new HashTable<string>(10);
        }

        [TestMethod]
        public void HashFunctionCollisionTest()
        {
            var s1 = "a";
            var s2 = "b";
            Assert.AreNotEqual(htable.Hash(s1), htable.Hash(s2));
        }

        [TestMethod]
        public void HashFunctionChangelingTest()
        {
            Func<string, int> newHashFunction = HashFunctions.StringHashFunction1;
            if (!htable.HashFunction.Equals(newHashFunction))
            {
                var testData = "1";
                int hash1 = htable.Hash(testData);
                htable.HashFunction = newHashFunction;
                int hash2 = htable.Hash(testData);
                Assert.AreNotEqual(hash1, hash2);
            }
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
