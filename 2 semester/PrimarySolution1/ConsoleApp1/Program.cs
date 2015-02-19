using System;
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

        public static void SortInsertion(int[] inputArray, uint arraySize)
        {
            for (uint n = 1; n < arraySize; ++n)
            {
                for (uint k = n; k > 0 && inputArray[k - 1] > inputArray[k]; --k)
                {
                    Swap(ref inputArray[k - 1], ref inputArray[k]);
                }
            }
        }

        public static void MatrixPrintSpiral(int[,] matrix, uint matrixSize)
        {
            if (matrixSize % 2 == 0)
            {
                Console.WriteLine("Conditions demand odd size of the matrix");
                return;
            }

            int centerI = (int)matrixSize / 2;
            int helpingI = 0;

            int row = centerI;
            int column = centerI;
            Console.WriteLine(matrix[row, column]);
            while (row < matrixSize - 1 && column < matrixSize - 1)
            {
                ++helpingI;
                ++column;
                for (; row >= centerI - helpingI; --row)
                {
                    Console.WriteLine(matrix[row, column]);
                }
                ++row;
                --column;
                for (; column >= centerI - helpingI; --column)
                {
                    Console.WriteLine(matrix[row, column]);
                }
                ++column;
                ++row;
                for (; row <= centerI + helpingI; ++row)
                {
                    Console.WriteLine(matrix[row, column]);                    
                }
                --row;
                ++column;
                for (; column <= centerI + helpingI; ++column)
                {
                    Console.WriteLine(matrix[row, column]);
                }
                --column;
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
                int[,] i = { { 11, 14, 13, 12, 15 }, { 23, 24, 21, 22, 25 }, { 34, 31, 33, 32, 35 }, { 42, 43, 41, 44, 45 }, {51, 52, 53, 54, 55} };
                SimpleMeth.MatrixPrintSpiral(i, 5);
            }
        }
    }
}