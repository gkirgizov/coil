using System;

namespace Task2
{
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
