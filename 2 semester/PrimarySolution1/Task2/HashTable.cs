using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Hash table based on lists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashTable<T>
    {
        private List<IList<T>> table;

        /// <summary>
        /// Hash function without hash table size correction
        /// </summary>
        public Func<T, int> HashFunction { get; set; }

        public HashTable(int startCapacity)
        {
            this.table = new List<IList<T>>((int)startCapacity);
            for (; startCapacity > 0; --startCapacity)
            {
                this.table.Add(null);
            }
            this.HashFunction = HashFunctionDefault;
        }

        public HashTable(int startCapacity, Func<T, int> hashFunc)
            : this(startCapacity)
        {
            this.HashFunction = hashFunc;
        }

        /// <summary>
        /// Return hash code of the data according to hash table size
        /// </summary>
        public int Hash(T hashedData)
        {
            return HashFunction(hashedData) % table.Capacity;
        }

        private int HashFunctionDefault(T hashedData)
        {
            return Math.Abs(hashedData.GetHashCode());
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
