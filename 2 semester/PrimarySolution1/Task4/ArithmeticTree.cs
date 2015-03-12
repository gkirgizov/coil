using System;

namespace Task4
{
    /// <summary>
    /// Main parent abstracn class for expression parse tree
    /// </summary>
    public abstract class ArithmeticTree : Tree<string>
    {
        public ArithmeticTree() { }

        public ArithmeticTree(string newData)
            : base(newData) { }

        /// <summary>
        /// Add new item to the tree
        /// </summary>
        public void Add(ArithmeticTree newItem)
        {
            if (this.Left == null)
            {
                this.Left = newItem;
            }
            else
            {
                this.Right = newItem;
            }
        }

        /// <summary>
        /// Calculate expression parsed in the tree
        /// </summary>
        public abstract int Calc();

        /// <summary>
        /// Return expression in the reverse polish notation
        /// </summary>
        public string Print()
        {
            string result = "";
            PrintRecursion(ref result);
            return result;
        }

        protected ArithmeticTree Left { get; set; }
        protected ArithmeticTree Right { get; set; }

        private void PrintRecursion(ref string result)
        {
            result = String.Concat(result, " ", this.Root);
            if (this.Left != null)
            {
                string leftHalf = this.Left.Print();
                result = String.Concat(result, " ", leftHalf);
            }
            if (this.Right != null)
            {
                string rightHalf = this.Right.Print();
                result = String.Concat(result, " ", rightHalf);
            }
        }
    }
}
