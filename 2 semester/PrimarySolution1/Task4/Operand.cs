using System;

namespace Task4
{
    /// <summary>
    /// Allows to use int data in the arithmetic tree
    /// </summary>
    public class Operand : ArithmeticTree
    {
        public Operand() { }

        public Operand(string newData)
            : base(newData) { }

        /// <summary>
        /// Calculate subtree, returns simple int item
        /// </summary>
        public override int Calc()
        {
            return Int32.Parse(this.Root);
        }
    }
}