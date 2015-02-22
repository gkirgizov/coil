using System;

namespace Task2
{
    interface MyStack<T>
    {
        uint Size
        {
            get;
        }

        void Push(T newData);

        T Pop();
    }

    class ArrayStack<T> : MyStack<T>
    {
        private uint capacity;
        private uint size;
        private T[] data;

        public ArrayStack(uint startCapacity = 128)
        {
            this.data = new T[startCapacity];
            this.capacity = startCapacity;
            this.size = 0;
        }

        public ArrayStack(T newData, uint startCapacity = 128)
            :this(startCapacity)
        {
            this.size = 1;
            this.data[0] = newData;
        }

        public uint Size
        {
            get { return this.size; }
        }

        public uint Capacity
        {
            get { return this.capacity; }
        }

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

        public T Pop()
        {
            T returned = this.data[this.size - 1];
            this.data[this.size - 1] = default(T);
            --this.size;
            return returned;
        }
    }

    //TODO: LinkedStack

    interface MyList<T>
    {
        uint Size
        {
            get;
        }

        void Add(T newData, int index);

        T Get(uint index);

        void Delete(T deletedData);
    }

    class LinkedList<T> : MyList<T>
    {
        private class LinkedListElement<T2>
        {
            private T2 data;
            private LinkedListElement<T2> next;
            private LinkedListElement<T2> prev;

            public LinkedListElement()
            { }

            public LinkedListElement(T2 newData)
            {
                this.data = newData;
            }

            public LinkedListElement<T2> Next
            {
                set { next = value; }
                get { return next; }
            }

            public LinkedListElement<T2> Prev
            {
                set { prev = value; }
                get { return prev; }
            }

            public T2 Data
            {
                set { data = value; }
                get { return data; }
            }
        }

        private LinkedListElement<T> head;
        private LinkedListElement<T> tail;
        private uint size;

        public LinkedList()
        {
            this.size = 0;
        }

        public LinkedList(T newData)
        {
            this.tail = new LinkedListElement<T>(newData);
            this.head = this.tail;
            this.size = 1;
        }

        public uint Size
        {
            get { return size; }
        }

        //Add new element in list to spot with index.
        //If index = 0 add to head. If index < 0 add to tail.
        public void Add(T addedData, int index = -1)
        {
            ++this.size;
            LinkedListElement<T> newElement = new LinkedListElement<T>(addedData);
            if (this.head != null)
            {
                LinkedListElement<T> ptr = this.head;
                if (index < 0)
                {
                    ptr = this.tail;
                }
                else if (index == 0)
                {
                    newElement.Next = this.head;
                    this.head.Prev = newElement;
                    this.head = newElement;
                    return;
                }
                else
                {
                    for (; ptr != this.tail; --index)
                    {
                        ptr = ptr.Next;
                        if (index == 0)
                        {
                            newElement.Next = ptr;
                            newElement.Prev = ptr.Prev;
                            ptr.Prev = newElement;
                            return;
                        }
                    }
                }
                newElement.Prev = ptr;
                ptr.Next = newElement;
                this.tail = newElement;
            }
            else
            {
                this.tail = newElement;
                this.head = this.tail;
            }
        }

        public T Get(uint index)
        {
            if (this.head != null)
            {
                LinkedListElement<T> ptr = this.head;
                for (; ptr != this.tail && index >= 0; --index)
                {
                    ptr = ptr.Next;
                }
                if (index == 0)
                {
                    return ptr.Data;
                }
            }
            //exception
            return default(T);
        }

        public void Delete(T deletedData)
        {
            LinkedListElement<T> ptr = this.head;
            while (ptr != null)
            {
                if (deletedData.Equals(ptr.Data))
                {
                    if (this.head == this.tail)
                    {
                        this.head = null;
                        this.tail = null;
                        ptr = null;
                    }
                    else
                    {
                        ptr.Next.Prev = ptr.Prev;
                        ptr.Prev.Next = ptr.Next;
                        ptr = null;
                    }
                }
            }
        }
    }

    //TODO: HTable
    class HashTable<T>
    {
        MyList<T> table;

    }

    class Program
    {
        static void Main(string[] args)
        {
            //ArrayStack<int> stck = new ArrayStack<int>();
            //stck.Push(27);
            //stck.Push(21);
            //Console.WriteLine(stck.Pop());
            //Console.WriteLine(stck.Pop());
            LinkedList<int> lst = new LinkedList<int>(55);
            Console.Write(" ___ ");
        }
    }
}
