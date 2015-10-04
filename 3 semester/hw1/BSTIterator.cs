using System;
using System.Collections.Generic;

namespace hw1 {
    /// <summary>
    /// Iterator for binary tree. Breadth-First by default.
    /// </summary>
    /// <typeparam name="T">Type of data in data structure</typeparam>
    public class BSTIterator<T> : IIterator<T> {

        public T Current {
            get { return current.Data; }
        }

        public BSTIterator(IBinaryTree<T> parentObj, BinaryTreeNode<T> startNode, IteratorMode mode) {
            this.parentObj = parentObj;
            this.startNode = startNode;
            this.current = startNode;
            this.Mode = mode;
            detourList = new LinkedList<BinaryTreeNode<T>>();
        }

        public T Next() {
            if (IsEmpty()) {
                throw new NullReferenceException();
            }

            T returning = current.Data;
            if (Mode == IteratorMode.BreadthFirst) {
                if (current.Left != null) {
                    detourList.AddLast(current.Left);
                }
                if (current.Right != null) {
                    detourList.AddLast(current.Right);
                }
            } else {
                if (current.Right != null) {
                    detourList.AddFirst(current.Right);
                }
                if (current.Left != null) {
                    detourList.AddFirst(current.Left);
                }
            }

            if (detourList.Count == 0) {
                current = null;
            } else {
                current = detourList.First.Value;
                detourList.RemoveFirst();
            }
            return returning;
        }

        public bool IsEmpty() {
            return current == null;
        }

        public void Reset() {
            current = startNode;
        }

        public bool Remove() {
            if (IsEmpty()) {
                return false;
            }
            return parentObj.Remove(Next());
        }

        public enum IteratorMode { DepthFirst, BreadthFirst }

        public IteratorMode Mode { get; }

        private IBinaryTree<T> parentObj;
        private BinaryTreeNode<T> startNode;
        private BinaryTreeNode<T> current;
        private LinkedList<BinaryTreeNode<T>> detourList;
    }
}
