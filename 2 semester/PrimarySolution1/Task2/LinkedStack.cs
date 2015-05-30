
namespace Task2
{
    /// <summary>
    /// Stack based on links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class LinkedStack<T> : Task2.IStack<T>
    {
        private class LinkedStackElement
        {
            private T data;
            private LinkedStackElement prev;

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

            public LinkedStackElement Prev
            {
                set { prev = value; }
                get { return prev; }
            }
        }

        private LinkedStackElement head;

        public LinkedStack()
        {
            this.Size = 0;
        }

        public LinkedStack(T newData)
        {
            this.head = new LinkedStackElement(newData);
            this.Size = 1;
        }

        /// <summary>
        /// Return number of items in stack
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Add item to stack
        /// </summary>
        public void Push(T newData)
        {
            LinkedStackElement newElement = new LinkedStackElement(newData);
            newElement.Prev = this.head;
            this.head = newElement;
            ++this.Size;
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
                --this.Size;
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
