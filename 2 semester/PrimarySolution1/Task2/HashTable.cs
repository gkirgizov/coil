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
        public HashTable(int startCapacity, Func<T, int> hashFunc)
        {
            this.table = new List<IList<T>>((int)startCapacity);
            for (; startCapacity > 0; --startCapacity)
            {
                this.table.Add(null);
            }
            this.hashfunction = hashFunc;
        }

        /// <summary>
        /// Hash function without hash table size correction
        /// </summary>
        public Func<T, int> HashFunction
        {
            get { return hashfunction; }

            set
            {
                var tempList = new LinkedList<T>();
                foreach (var innerList in this.table)
                {
                    if (innerList != null)
                    {
                        foreach (var item in innerList)
                        {
                            tempList.Add(item);
                        }
                        innerList.Clear();
                    }
                }

                this.hashfunction = value;
                foreach (var item in tempList)
                {
                    this.Add(item);
                }
            }
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

        /// <summary>
        /// Return hash code of the data according to hash table size
        /// </summary>
        private int Hash(T hashedData)
        {
            return HashFunction(hashedData) % table.Capacity;
        }

        private Func<T, int> hashfunction;

        private List<IList<T>> table;
    }
}
