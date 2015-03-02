using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Stack calculator
    /// </summary>
    class CalcStack
    {
        private static int Operation(char key, int first, int second)
        {
            if (key == '+')
            {
                return first + second;
            }
            else if (key == '-')
            {
                return first - second;
            }
            else if (key == '*')
            {
                return first * second;
            }
            //exception for zero
            else if (key == '/')
            {
                if (second != 0)
                {
                    return first / second;
                }
            }
            return default(Int32);
        }

        /// <summary>
        /// Calculate expression inputted in the reverse polish notation
        /// </summary>
        public static int Calculate(string inputString, IStack<int> stack)
        {
            char[] separator = new char[] { ' ' };
            string[] tokens = inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                int tempValue;
                if (Int32.TryParse(token, out tempValue))
                {
                    stack.Push(tempValue);
                }
                else
                {
                    int secondOperand = stack.Pop();
                    int firstOperand = stack.Pop();
                    stack.Push(Operation(token[0], firstOperand, secondOperand));
                }
            }
            if (stack.Size == 1)
            {
                return stack.Top();
            }
            Console.WriteLine("There is a mistake somewhere in the input");
            return default(Int32);
        }
    }
}
