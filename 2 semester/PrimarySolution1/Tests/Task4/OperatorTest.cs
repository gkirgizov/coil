using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Tests.Task4
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void OperatorUsualCalcTest()
        {
            var tested = new Operator("+");
            var left = new Operand("10");
            var right = new Operand("17");
            tested.Add(left);
            tested.Add(right);
            Assert.AreEqual(27, tested.Calc());
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void OperatorDivideByZeroCalcTest()
        {
            var tested = new Operator("/");
            var left = new Operand("17");
            var right = new Operand("0");
            tested.Add(left);
            tested.Add(right);
            tested.Calc();
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(UnexpectedInputData))]
        public void OperatorUnexpectedDataTest()
        {
            var tested = new Operator("~");
            var left = new Operand("10");
            var right = new Operand("17");
            tested.Add(left);
            tested.Add(right);
            tested.Calc();
            Assert.Fail();
        }
    }
}
