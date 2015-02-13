using System;
using System.Collections.Generic;
using System.Text;
//using System.Threading.Tasks;

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
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
