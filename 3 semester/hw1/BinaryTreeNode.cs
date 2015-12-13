using System;

namespace hw1 {

    public class BinaryTreeNode<T> {
        public BinaryTreeNode(T data) {
            this.Data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right) {
            this.Left = left;
            this.Right = right;
        }

        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }
    }
}
