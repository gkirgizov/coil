using System;

namespace hw1 {
    public interface IBinaryTree<T>{

        /// <summary>
        /// Add new data to the tree.
        /// </summary>
        /// <param name="data"></param>
        void Add(T data);

        /// <summary>
        /// Remove that data from the tree.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True is removing was successful.</returns>
        bool Remove(T data);

        /// <summary>
        /// Check if data is containing in the tree.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Contains(T data);

        int Count { get; }
    }
}
