using System;

namespace Task2
{
    class MyStack<T>
    {
        private uint capacity;
        private uint size;
        private T[] data;

        public MyStack()
        {
            this.data = new T[128];
            this.capacity = 128;
            this.size = 0;
        }

        public MyStack(T newData)
        {
            this.data = new T[128];
            this.capacity = 128;
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
                //delete somehow old data array?
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

    class LinkedListElement<T>
    {
        private T data;
        public LinkedListElement<T> next;
        public LinkedListElement<T> prev;

        public LinkedListElement()
        { }

        public LinkedListElement(T newData)
        {
            this.data = newData;
        }

        public T Data
        {
            set { data = value; }
            get { return data; }
        }
    }

    class LinkedList<T>
    {
        private LinkedListElement<T> head;
        private LinkedListElement<T> tail;

        public LinkedList()
        { }

        public LinkedList(T newData)
        {
            this.tail = new LinkedListElement<T>(newData);
            this.head = this.tail;
        }

        //Add new element in list to spot with index.
        //If index = 0 add to head. If index < 0 add to tail.
        public void Add(T addedData, int index = -1)
        {
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
                    newElement.next = this.head;
                    this.head.prev = newElement;
                    this.head = newElement;
                    return;
                }
                else
                {
                    for (; ptr != this.tail; --index)
                    {
                        ptr = ptr.next;
                        if (index == 0)
                        {
                            newElement.next = ptr;
                            newElement.prev = ptr.prev;
                            ptr.prev = newElement;
                            return;
                        }
                    }
                }
                newElement.prev = ptr;
                ptr.next = newElement;
                this.tail = newElement;
            }
            else
            {
                this.tail = newElement;
                this.head = this.tail;
            }
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
                        //delete ptr?
                        this.head = null;
                        this.tail = null;
                        ptr = null;
                    }
                    else
                    {
                        //delete ptr?
                        ptr.next.prev = ptr.prev;
                        ptr.prev.next = ptr.next;
                        ptr = null;
                    }
                }
            }
        }

        public uint Size()
        {
            uint listSize = 0;
            if (this.head != null)
            {
                LinkedListElement<T> ptr = this.head;
                for (; ptr.next != null; ++listSize)
                {
                    ptr = ptr.next;
                }
            }
            return listSize;
        }

        class Program
        {
            static void Main(string[] args)
            {
                //MyStack<int> stck = new MyStack<int>();
                //stck.Push(27);
                //stck.Push(21);
                //Console.WriteLine(stck.Pop());
                //Console.WriteLine(stck.Pop());
                LinkedList<int> lst = new LinkedList<int>(55);
                Console.Write(" ___ ");
            }
        }
    }
}
