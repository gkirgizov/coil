﻿using System;

namespace Task2
{
    /// <summary>
    /// List based on links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IList<T>
    {
        private class LinkedListElement<T>
        {
            private T data;
            private LinkedListElement<T> next;
            private LinkedListElement<T> prev;

            public LinkedListElement()
            { }

            public LinkedListElement(T newData)
            {
                this.data = newData;
            }

            public LinkedListElement<T> Next
            {
                set { next = value; }
                get { return next; }
            }

            public LinkedListElement<T> Prev
            {
                set { prev = value; }
                get { return prev; }
            }

            public T Data
            {
                set { data = value; }
                get { return data; }
            }
        }

        private LinkedListElement<T> head;
        private LinkedListElement<T> tail;
        private int size;

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

        /// <summary>
        /// Returns number of items in list
        /// </summary>
        public int Size { get { return this.size; } }

        /// <summary>
        /// Add new element in list to spot with index.
        /// If index = 0 add to head. If index < 0 add to tail.
        /// </summary>
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

        /// <summary>
        /// Returns item by index, returns default value if index is out of range
        /// </summary>
        public T Get(int index)
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

        /// <summary>
        /// Returns true if item is in the list
        /// </summary>
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

        /// <summary>
        /// Delete item by value
        /// </summary>
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
}
