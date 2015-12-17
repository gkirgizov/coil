using System.Collections.Generic;

namespace hw3 {
    public interface IGraphEnumerator<T> : IEnumerator<T> {
        /// <summary>
        /// Return index of the current.
        /// Index depends on the order of adding item in the graph.
        /// </summary>
        int CurrentIndex { get; }

        /// <summary>
        /// Returns list of the neighbors of the current item.
        /// </summary>
        /// <returns></returns>
        ICollection<T> GetNeighbors();

        /// <summary>
        /// Returns indexes of the neighbors of the current item.
        /// </summary>
        /// <returns></returns>
        ICollection<int> GetNeighborsIndexes();

        /// <summary>
        /// Returns true if Current is the last item in the graph.
        /// </summary>
        /// <returns></returns>
        bool IsLast();
    }
}
