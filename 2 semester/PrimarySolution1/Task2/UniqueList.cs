using System;

namespace Task2
{
    /// <summary>
    /// UniqueList doesn't contain repeated data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UniqueList<T> : LinkedList<T>
    {
        /// <summary>
        /// Add new element in list to spot with index.
        /// If index = 0 add to head. If index less 0 add to tail.
        /// </summary>
        public override void Add(T addedData, int index = -1)
        {
            if (base.Search(addedData))
            {
                throw new AddExistingItemException();
            }
            base.Add(addedData, index);
        }
    }
}
