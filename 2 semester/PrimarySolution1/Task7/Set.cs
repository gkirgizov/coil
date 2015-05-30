using System.Collections;
using System.Collections.Generic;

namespace Task7
{
    public class Set<T> : IEnumerable<T>, ICollection<T>
    {
        public Set()
        {
            this.dataList = new List<T>();
            this.Count = 0;
            this.IsReadOnly = false;
        }

        /// <summary>
        /// Number of the elements in the set
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Add data to the set
        /// </summary>
        /// <param name="data">Added data</param>
        public void Add(T data)
        {
            if (!this.Contains(data))
            {
                this.dataList.Add(data);
                ++this.Count;
            }
        }

        /// <summary>
        /// Remove data from the set
        /// </summary>
        /// <param name="data">Removed data</param>
        /// <returns>true if removing was successful</returns>
        public bool Remove(T data)
        {
            if (this.dataList.Remove(data))
            {
                --this.Count;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove all data
        /// </summary>
        public void Clear()
        {
            this.dataList.Clear();
            this.Count = 0;
        }

        /// <summary>
        /// Checking data in the set
        /// </summary>
        /// <param name="data">Checked data</param>
        /// <returns>true if data is in the set</returns>
        public bool Contains(T data)
        {
            return this.dataList.Contains(data);
        }

        /// <summary>
        /// Copy all data to the array from index in the array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex">Start index to copying</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in this)
            {
                array[arrayIndex] = item;
                ++arrayIndex;
            }
        }

        /// <summary>
        /// Union with other IEnumerable object
        /// </summary>
        /// <param name="other">IEnumerable object</param>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var otherItem in other)
            {
                if (!this.Contains(otherItem))
                {
                    this.Add(otherItem);
                }
            }
        }

        /// <summary>
        /// Intersect with other IEnumerable object
        /// </summary>
        /// <param name="other">IEnumerable object</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            var removingItems = new Set<T>();
            foreach (var item in this)
            {
                bool IsItemInIntersection = false;
                foreach (var otherItem in other)
                {
                    if (item.Equals(otherItem))
                    {
                        IsItemInIntersection = true;
                    }
                }
                if (!IsItemInIntersection)
                {
                    removingItems.Add(item);
                }
            }

            foreach (var item in removingItems)
            {
                this.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.dataList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private List<T> dataList;
    }
}
