using System;

namespace Task2
{
    /// <summary>
    /// Stack based on the array
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class ArrayStack<T> : IStack<T>
    {
        private int capacity;
        private int size;
        private T[] data;

        public ArrayStack(int startCapacity = 128)
        {
            this.data = new T[startCapacity];
            this.capacity = startCapacity;
            this.size = 0;
        }

        public ArrayStack(T newData, int startCapacity = 128)
            : this(startCapacity)
        {
            this.size = 1;
            this.data[0] = newData;
        }
        
        /// <summary>
        /// Return number of the elements in the stack
        /// </summary>
        public int Size { get { return this.size; } }

        /// <summary>
        /// Return max size of the stack without expansion
        /// </summary>
        public int Capacity { get { return this.capacity; } }

        /// <summary>
        /// Add item to the stack
        /// </summary>
        public void Push(T newData)
        {
            if (this.size == this.capacity)
            {
                this.capacity <<= 1;
                T[] newDataArray = new T[this.capacity];
                for (uint i = 0; i < this.size; ++i)
                {
                    newDataArray[i] = this.data[i];
                }
                this.data = newDataArray;
            }
            this.data[this.size] = newData;
            ++this.size;
        }

        /// <summary>
        /// Delete top item and returns it
        /// </summary>
        public T Pop()
        {
            if (this.size > 0)
            {
                T returned = this.data[this.size - 1];
                this.data[this.size - 1] = default(T);
                --this.size;
                return returned;
            }
            //exception
            return default(T);
        }

        /// <summary>
        /// Return top item
        /// </summary>
        public T Top()
        {
            if (this.size > 0)
            {
                return this.data[0];
            }
            //exception
            return default(T);
        }
    }
}
