using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class SimpleMeth
    {
        public static uint FactorialI(int calcThis)
        {
            uint result = 1;
            for (uint n = 1; n <= calcThis; ++n)
            {
                result *= n;
            }
            return result;
        }
        
        public static uint FibonacciI(uint indexOfNumber)
        {
            if (indexOfNumber < 3)
            {
                return 1;
            }
            else
            {
                uint temp1 = 1;
                uint temp2 = 1;
                for (; indexOfNumber > 2; --indexOfNumber)
                {
                    uint temp3 = temp1 + temp2;
                    temp1 = temp2;
                    temp2 = temp3;
                }
                return temp2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int inp = Console.Read() - 48;
            Console.WriteLine();
        }
    }
}
