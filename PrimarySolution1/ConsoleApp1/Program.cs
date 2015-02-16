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

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        public static void Sortinsertion(int[] inputArray, uint arraySize)
        {
            for (uint n = 1; n < arraySize; ++n)
            {
                for (uint k = n; k > 0 && inputArray[k - 1] > inputArray[k]; --k)
                {
                    Swap(ref inputArray[k - 1], ref inputArray[k]);
                }
            }
        }

        public static void MatrixSort(int[,] matrix, uint columns, uint rows, uint mainRow = 0)
        {
            uint[] swapArray = new uint[columns];
            for (uint n = 1; n < columns; ++n)
            {
                for (uint k = n; k > 0 && matrix[mainRow, k - 1] > matrix[mainRow, k]; --k)
                {
                    for (uint j = 0; j < rows; ++j)
                    {
                        Swap(ref matrix[j, k - 1], ref matrix[j, k]);
                    }
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                int[,] i = { { 11, 14, 13, 12 }, { 23, 24, 21, 22 }, { 34, 31, 33, 32 }, { 42, 43, 41, 44 } };

                for (uint k = 0; k < 4; ++k)
                {
                    for (uint k1 = 0; k1 < 4; ++k1)
                    {
                        Console.Write(i[k, k1]);
                        Console.Write("  ");
                    }
                    Console.WriteLine();
                }

                SimpleMeth.MatrixSort(i, 4, 4);
            }
        }
    }
}