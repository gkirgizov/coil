using System;
using System.Collections.Generic;

namespace ControlWork2
{
    /// <summary>
    /// Iterator for binary tree
    /// </summary>
    /// <typeparam name="int">Type of data in iterating binary tree</typeparam>
    public class Iterator : IIterator<int>
    {
        public Iterator(BinTree tree)
        {
            this.tree = tree;
            this.current = tree;
            treeDetour = new Queue<BinTree>();
        }

        public int Next()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException();
            }

            int returning = current.Data;
            if (current.Left != null)
            {
                treeDetour.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
                treeDetour.Enqueue(current.Right);
            }

            if (treeDetour.Count == 0)
            {
                current = null;
            }
            else
            {
                current = treeDetour.Dequeue();
            }
            return returning;
        }

        public bool IsEmpty()
        {
            return current == null;
        }

        public void Reset()
        {
            current = tree;
        }

        public bool Remove()
        {
            if (IsEmpty())
            {
                return false;
            }
            tree.Remove(current.Data);
            return true;
        }

        private BinTree tree;
        private BinTree current;
        private Queue<BinTree> treeDetour;
    }
}
