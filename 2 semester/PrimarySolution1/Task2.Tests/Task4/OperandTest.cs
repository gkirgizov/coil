using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Tests.Task4
{
    [TestClass]
    public class OperandTest
    {
        [TestMethod]
        public void OperandCalcTest()
        {
            var tested = new Operand("7");
            Assert.AreEqual(7, tested.Calc());
        }

        [TestMethod]
        public void OperandPrintTest()
        {
            var tested = new Operand("7");
            Assert.AreEqual("7", tested.Print().Trim());
        }
    }
}
