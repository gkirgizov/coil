using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Interface for list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Return number of items in list
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Add new element in list to spot with index.
        /// If index = 0 add to head. If index < 0 add to tail.
        /// </summary>
        void Add(T newData, int index = -1);

        /// <summary>
        /// Return item by index, returns default value if index is out of range
        /// </summary>
        T Get(int index);

        /// <summary>
        /// Return true if item is in the list
        /// </summary>
        bool Search(T searchedData);

        /// <summary>
        /// Delete item by value
        /// </summary>
        void Delete(T deletedData);

        /// <summary>
        /// Delete all items
        /// </summary>
        void Clear();
    }
}
