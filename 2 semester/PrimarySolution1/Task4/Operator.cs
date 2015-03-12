using System;

namespace Task4
{
    /// <summary>
    /// Allows to use operators in the arithmetic tree
    /// </summary>
    public class Operator : ArithmeticTree
    {
        public Operator() { }

        public Operator(string newData)
            : base(newData) { }

        /// <summary>
        /// Calculate subtree
        /// </summary>
        public override int Calc()
        {
            return Operation(this.Root[0], this.Left.Calc(), this.Right.Calc());
        }

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
            else if (key == '/')
            {
                return first / second;
            }
            throw new UnexpectedInputData("Unxpected key symbol");
        }
    }
}
