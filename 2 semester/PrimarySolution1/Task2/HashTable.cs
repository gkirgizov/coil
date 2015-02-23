using System;
using System.Collections.Generic;

namespace Task2
{
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
}
