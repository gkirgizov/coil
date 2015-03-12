using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"...\...\Exercise2Expression.txt";
            var res = ArithmeticTreeCalculator.CreateTree(path);
            Console.WriteLine(res.Print());
            Console.WriteLine(res.Calc());
        }
    }
}