using System.Collections;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// List based on links
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : Task2.IList<T>, IEnumerable<T>
    {
        private class LinkedListElement
        {
            private T data;
            private LinkedListElement next;
            private LinkedListElement prev;

            public LinkedListElement()
            { }

            public LinkedListElement(T newData)
            {
                this.data = newData;
            }

            public LinkedListElement Next
            {
                set { next = value; }
                get { return next; }
            }

            public LinkedListElement Prev
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

        private LinkedListElement head;
        private LinkedListElement tail;

        public LinkedList()
        {
            this.Size = 0;
        }

        public LinkedList(T newData)
        {
            this.tail = new LinkedListElement(newData);
            this.head = this.tail;
            this.Size = 1;
        }

        /// <summary>
        /// Returns number of items in list
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Add new element in list to spot with index.
        /// If index = 0 add to head. If index less 0 add to tail.
        /// </summary>
        public virtual void Add(T addedData, int index = -1)
        {
            ++this.Size;
            LinkedListElement newElement = new LinkedListElement(addedData);
            if (this.head != null)
            {
                LinkedListElement ptr = this.head;
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
                LinkedListElement ptr = this.head;
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
                LinkedListElement ptr = this.head;
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
        /// Delete first entry of item by value
        /// </summary>
        public void Delete(T deletedData)
        {
            LinkedListElement ptr = this.head;
            bool isDeletionSuccesful = false;
            while (ptr != null)
            {
                if (deletedData.Equals(ptr.Data))
                {
                    isDeletionSuccesful = true;
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
                    --this.Size;
                    return;
                }
                ptr = ptr.Next;
            }
            if (!isDeletionSuccesful)
            {
                throw new DeleteNonexistentItemException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListElement current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
