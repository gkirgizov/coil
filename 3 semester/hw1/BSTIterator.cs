using System.Collections;
using System.Collections.Generic;

namespace hw1 {
    /// <summary>
    /// Iterator for binary tree. Breadth-First by default.
    /// </summary>
    /// <typeparam name="T">Type of data in data structure</typeparam>
    public class BSTIterator<T> : IEnumerator<T> {

        public T Current {
            get { return current.Data; }
        }

        public BSTIterator(IBinaryTree<T> parentObj, BinaryTreeNode<T> startNode, IteratorMode mode) {
            this.parentObj = parentObj;
            this.startNode = startNode;
            this.current = startNode;
            this.isFirst = true;
            this.Mode = mode;
            detourList = new LinkedList<BinaryTreeNode<T>>();
        }

        public bool MoveNext() {
            if (current == null) {
                return false;
            }

            if (isFirst) {
                isFirst = false;
                return true;
            }

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
                return false;
            } else {
                current = detourList.First.Value;
                detourList.RemoveFirst();
            }
            return true;
        }

        public void Reset() {
            current = startNode;
        }

        public void Dispose() { }

        public enum IteratorMode { DepthFirst, BreadthFirst }

        public IteratorMode Mode { get; }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        private bool isFirst;
        private IBinaryTree<T> parentObj;
        private BinaryTreeNode<T> startNode;
        private BinaryTreeNode<T> current;
        private LinkedList<BinaryTreeNode<T>> detourList;
    }
}
