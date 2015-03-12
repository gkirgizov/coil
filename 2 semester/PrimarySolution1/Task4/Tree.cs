using System;

namespace Task4
{
    /// <summary>
    /// Definition of the tree
    /// </summary>
    public abstract class Tree<T>
    {
        /// <summary>
        /// Contains data
        /// </summary>
        public T Root { get; protected set; }

        public Tree() { }

        public Tree(T newData)
            : this()
        {
            this.Root = newData;
        }

        //public abstract void Add(T newData);

        //public abstract void Delete(T deletedData);

        //protected Tree<T> left;
        //protected Tree<T> right;
    }
}
