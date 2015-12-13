using System;
using System.Collections;
using System.Collections.Generic;

namespace hw1 {
    public class BinarySearchTree : IBinaryTree<int> {

        public BinarySearchTree(BSTIterator<int>.IteratorMode mode = BSTIterator<int>.IteratorMode.BreadthFirst) {
            Count = 0;
            Mode = mode;
        }

        public BinarySearchTree(int firstItem, BSTIterator<int>.IteratorMode mode = BSTIterator<int>.IteratorMode.BreadthFirst) {
            root = new BinaryTreeNode<int>(firstItem);
            Count = 1;
            Mode = mode;
        }

        public virtual void Add(int data) {
            var newNode = new BinaryTreeNode<int>(data);
            if (root == null) {
                root = newNode;
            } else {
                var current = root;
                BinaryTreeNode<int> parent = null;
                while (current.Data != data) {
                    parent = current;
                    current = data > current.Data ? current.Right : current.Left;

                    if (current == null) {
                        if (data > parent.Data) {
                            parent.Right = newNode;
                        } else {
                            parent.Left = newNode;
                        }
                        break;
                    }
                }
            }
            ++Count;
        }

        public virtual bool Remove(int data) {
            if (root == null) {
                return false;
            }

            var current = root;
            BinaryTreeNode<int> parent = null;
            while (current.Data != data) {
                parent = current;
                current = data > current.Data ? current.Right : current.Left;
                if (current == null) {
                    return false;
                }
            }

            --Count;
            // CASE 1: If current has no right child, then current's left child becomes
            //         the node pointed to by the parent
            if (current.Right == null) {
                if (parent == null) {
                    root = current.Left;
                } else if (parent.Data > current.Data) {
                    parent.Left = current.Left;
                } else if (parent.Data < current.Data) {
                    parent.Right = current.Left;
                }

                // CASE 2: If current's right child has no left child, then current's right child
                //         replaces current in the tree
            } else if (current.Right.Left == null) {
                current.Right.Left = current.Left;

                if (parent == null) {
                    root = current.Right;
                } else if (parent.Data > current.Data) {
                    parent.Left = current.Right;
                } else if (parent.Data < current.Data) {
                    parent.Right = current.Right;
                }

                // CASE 3: If current's right child has a left child, replace current with current's
                //          right child's left-most descendent
            } else {
                var leftmost = current.Right.Left;
                var lmParent = current.Right;
                while (leftmost.Left != null) {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }

                lmParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null) {
                    root = leftmost;
                } else {
                    if (parent.Data > current.Data) {
                        parent.Left = leftmost;
                    } else if (parent.Data < current.Data) {
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }

        public bool Contains(int data) {
            if (root == null) {
                return false;
            }
            var current = root;
            while (current != null) {
                if (current.Data == data) {
                    return true;
                }
                current = data > current.Data ? current.Right : current.Left;
            }
            return false;
        }

        public IEnumerator<int> GetEnumerator() {
            return new BSTIterator<int>(this, root, Mode);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public int Count { get; private set; }

        /// <summary>
        /// Set breadth-first or depth-first traverse.
        /// </summary>
        public BSTIterator<int>.IteratorMode Mode { get; set; }

        private BinaryTreeNode<int> root;
    }
}
