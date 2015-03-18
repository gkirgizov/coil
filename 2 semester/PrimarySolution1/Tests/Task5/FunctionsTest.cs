using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task5;

namespace Tests.Task5
{
    [TestClass]
    public class FunctionsTest
    {
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int> { 1, 2, 3 };
        }

        [TestMethod]
        public void MapTest()
        {
            var newList = Functions.Map(list, x => ++x);
            for (var i = 0; i < 3; ++i)
            {
                Assert.AreEqual(++list[i], newList[i]);
            }
        }

        [TestMethod]
        public void FilterTest()
        {
            var newList = Functions.Filter(list, item => (item % 2) == 1);
            Assert.IsFalse(newList.Contains(2));
            Assert.IsTrue(newList.Contains(1));
            Assert.IsTrue(newList.Contains(3));
        }

        [TestMethod]
        public void FoldTest()
        {
            var startValue = 1;
            var res = Functions.Fold(list, startValue, (value, item) => value + item);
            var testRes = startValue;
            foreach(var item in list)
            {
                testRes += item;
            }
            Assert.AreEqual(testRes, res);
        }
    }
}
