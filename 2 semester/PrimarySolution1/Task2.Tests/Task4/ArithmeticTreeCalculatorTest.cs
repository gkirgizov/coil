using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4;

namespace Tests.Task4
{
    [TestClass]
    public class ArithmeticTreeCalculatorTest
    {
        [TestMethod]
        public void EntireProgramMainArithmeticTest()
        {
            string path = @"...\...\Exercise2Expression.txt";
            var tests = new string[2];
            tests[0] = "(* (+ 1 1) 2)";
            tests[1] = "0";
            var answers = new int[2];
            answers[0] = 4;
            answers[1] = 0;
            for (var i = 0; i < tests.Length; ++i)
            {
                File.WriteAllText(path, tests[i]);
                int calculated = ArithmeticTreeCalculator.CalcTree(path);
                Assert.AreEqual(answers[i], calculated);
            }
        }
    }
}
