using System;

namespace Task2
{
    /// <summary>
    /// Interface for stack
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IStack<T>
    {
        /// <summary>
        /// Return number of items in stack
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Add item to stack
        /// </summary>
        void Push(T newData);

        /// <summary>
        /// Delete top item and return it
        /// </summary>
        T Pop();

        /// <summary>
        /// Return top item
        /// </summary>
        T Top();
    }
}
