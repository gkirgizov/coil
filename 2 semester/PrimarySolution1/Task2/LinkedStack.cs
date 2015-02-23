using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
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
}
