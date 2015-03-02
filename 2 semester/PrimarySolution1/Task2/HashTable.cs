using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Hash table based on lists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class HashTable<T>
    {
        private List<IList<T>> table;

        public HashTable(int startCapacity)
        {
            this.table = new List<IList<T>>((int)startCapacity);
            for (; startCapacity > 0; --startCapacity)
            {
                this.table.Add(null);
            }
        }

        private int Hash(T hashedData)
        {
            return Math.Abs(hashedData.GetHashCode() % table.Capacity);
        }

        /// <summary>
        /// Add item to hash table
        /// </summary>
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

        /// <summary>
        /// Delete item from hash table if it exist
        /// </summary>
        public void Delete(T deletedData)
        {
            int hash = Hash(deletedData);
            table[hash].Delete(deletedData);
        }

        /// <summary>
        /// Returns true if item is in the hash table
        /// </summary>
        public bool Search(T searchedData)
        {
            int hash = Hash(searchedData);
            return this.table[hash].Search(searchedData);
        }
    }
}
