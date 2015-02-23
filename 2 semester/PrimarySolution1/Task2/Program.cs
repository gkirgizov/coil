using System;
using System.Collections.Generic;

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

        T Top();
    }
  
    class LinkedStack<T> : MyStack<T>
    {
        private class LinkedStackElement<T2>
        {
            private T2 data;
            private LinkedStackElement<T2> prev;

            public LinkedStackElement()
            { }

            public LinkedStackElement(T2 newData)
            {
                this.data = newData;
            }

            public T2 Data
            {
                set { data = value; }
                get { return data; }
            }

            public LinkedStackElement<T2> Prev
            {
                set { prev = value; }
                get { return prev; }
            }
        }

        private LinkedStackElement<T> head;
        private uint size;

        public LinkedStack()
        {
            this.size = 0;
        }

        public LinkedStack(T newData)
        {
            this.head = new LinkedStackElement<T>(newData);
            this.size = 1;
        }

        public uint Size
        {
            get { return this.size; }
        }

        public void Push(T newData)
        {
            LinkedStackElement<T> newElement = new LinkedStackElement<T>(newData);
            newElement.Prev = this.head;
            this.head = newElement;
            ++this.size;
        }

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
            : this(startCapacity)
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

        //TODO exception
        public T Pop()
        {
            T returned = this.data[this.size - 1];
            this.data[this.size - 1] = default(T);
            --this.size;
            return returned;
        }

        public T Top()
        {
            if (this.size >= 0)
            {
                return this.data[0];
            }
            //exception
            return default(T);
        }
    }

    interface MyList<T>
    {
        uint Size
        {
            get;
        }

        void Add(T newData, int index = -1);

        T Get(uint index);

        bool Search(T searchedData);

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
                for (; ptr != this.tail && index > 0; --index)
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

        public bool Search(T searchedData)
        {
            if (this.head != null)
            {
                LinkedListElement<T> ptr = this.head;
                while (ptr != null)
                {
                    if (ptr.Data.Equals(searchedData))
                    {
                        return true;
                    }
                    ptr = ptr.Next;
                }
            }
            return false;
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
                    }
                    else if (ptr == this.tail)
                    {
                        this.tail = this.tail.Prev;
                        this.tail.Next = null;
                    }
                    else if (ptr == this.head)
                    {
                        this.head = this.head.Next;
                        this.head.Prev = null;
                    }
                    else
                    {
                        ptr.Next.Prev = ptr.Prev;
                        ptr.Prev.Next = ptr.Next;
                    }
                    ptr = null;
                    --this.size;
                    return;
                }
                ptr = ptr.Next;
            }
        }
    }

    class HashTable<T>
    {
        private List<MyList<T>> table;

        public HashTable(uint startCapacity)
        {
            this.table = new List<MyList<T>>((int)startCapacity);
            for (; startCapacity > 0; --startCapacity)
            {
                this.table.Add(null);
            }
        }

        private int Hash(T hashedData)
        {
            return Math.Abs(hashedData.GetHashCode() % table.Capacity);
        }

        //How to change LinkedList<T> to the parent MyList<T> ?
        public void Add(T newData)
        {
            int hash = Hash(newData);
            if (table[hash] == null)
            {
                table[hash] = new LinkedList<T>(newData);
            }
            else
            {
                table[hash].Add(newData);
            }
        }

        public void Delete(T deletedData)
        {
            int hash = Hash(deletedData);
            table[hash].Delete(deletedData);
        }

        public bool Search(T searchedData)
        {
            int hash = Hash(searchedData);
            return this.table[hash].Search(searchedData);
        }
    }

    class CalcStack
    {
        private static int Operation(char key, int first, int second)
        {
	        if (key == '+')
	        {
                return first + second;
	        }
	        else if (key == '-')
	        {
                return first - second;
	        }
	        else if (key == '*')
	        {
                return first * second;
	        }
	        //exception for zero
            else if (key == '/')
            {
                if (second != 0)
                {
                    return first / second;
                }
            }
            return default(Int32);            
        }

        public static int Calculate(ref string inputString)
        {
            MyStack<int> stack = new LinkedStack<int>();
            char[] separator = new char[] { ' ' };
            string[] tokens = inputString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                int tempValue;
                if (Int32.TryParse(token, out tempValue))
                {
                    stack.Push(tempValue);
                }
                else
                {
                    int secondOperand = stack.Pop();
                    int firstOperand = stack.Pop();
                    stack.Push(Operation(token[0], firstOperand, secondOperand));
                }
            }
            if (stack.Size == 1)
            {
                return stack.Top();
            }
            Console.WriteLine("There is a mistake somewhere in the input");
            return default(Int32);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> lst = new LinkedList<int>(55);
            //lst.Add(44);
            //lst.Add(33);

            //HashTable<string> ht = new HashTable<string>(7);
            //ht.Add("first");
            //ht.Add("second");
            //ht.Add("third");
            //ht.Add("fourth");
            //ht.Add("fifth");
            //ht.Add("sixth");
            //ht.Add("seventh");
            //ht.Add("eighth");
            //ht.Add("ninth");
            //ht.Add("ten");
            //ht.Add("eleven");
            //ht.Add("twelve");
            //ht.Add("thirteen");
            //ht.Add("fourteen");

            //ht.Delete("second");
            //ht.Delete("ten");
            //ht.Delete("first");
            //ht.Delete("something");

            //Console.WriteLine(ht.Search("something"));

            string inp = Console.ReadLine();
            Console.WriteLine(CalcStack.Calculate(ref inp));
        }
    }
}