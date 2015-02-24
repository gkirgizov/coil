using System;
using System.Collections.Generic;

namespace Task2
{
    //Hash table based on lists
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

        //Add item to hash table
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

        //Delete item from hash table if it exist
        public void Delete(T deletedData)
        {
            int hash = Hash(deletedData);
            table[hash].Delete(deletedData);
        }

        //Returns true if item is in the hash table
        public bool Search(T searchedData)
        {
            int hash = Hash(searchedData);
            return this.table[hash].Search(searchedData);
        }
    }
}
