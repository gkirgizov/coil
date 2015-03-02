using System;

namespace Task2
{
    /// <summary>
    /// Stack based on links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedStack<T> : IStack<T>
    {
        private class LinkedStackElement<T>
        {
            private T data;
            private LinkedStackElement<T> prev;

            public LinkedStackElement()
            { }

            public LinkedStackElement(T newData)
            {
                this.data = newData;
            }

            public T Data
            {
                set { data = value; }
                get { return data; }
            }

            public LinkedStackElement<T> Prev
            {
                set { prev = value; }
                get { return prev; }
            }
        }

        private int size;        
        private LinkedStackElement<T> head;

        public LinkedStack()
        {
            this.size = 0;
        }

        public LinkedStack(T newData)
        {
            this.head = new LinkedStackElement<T>(newData);
            this.size = 1;
        }

        /// <summary>
        /// Return number of items in stack
        /// </summary>
        public int Size { get { return this.size; } }

        /// <summary>
        /// Add item to stack
        /// </summary>
        public void Push(T newData)
        {
            LinkedStackElement<T> newElement = new LinkedStackElement<T>(newData);
            newElement.Prev = this.head;
            this.head = newElement;
            ++this.size;
        }

        /// <summary>
        /// Delete top item and return it
        /// </summary>
        public T Pop()
        {
            if (this.head != null)
            {
                T returned = this.head.Data;
                this.head = this.head.Prev;
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
            if (this.head != null)
            {
                return this.head.Data;
            }
            //exception
            return default(T);
        }
    }
}
