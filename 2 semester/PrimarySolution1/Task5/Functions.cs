using System;
using System.Collections.Generic;

namespace Task5
{
    /// <summary>
    /// Functions for int list
    /// </summary>
    public class Functions
    {
        /// <summary>
        /// Receives list and function transformated this list, returns transformated list
        /// </summary>
        public static List<int> Map(List<int> list, Func<int, int> func)
        {
            var newList = new List<int>();
            foreach (var item in list)
            {
                newList.Add(func(item));
            }
            return newList;
        }

        /// <summary>
        /// Returns list with items satisfacting to predicate "func"
        /// </summary>
        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            return list.FindAll(x => func(x));
        }

        /// <summary>
        /// Applies func to every item in the list according to start value "value"
        /// </summary>
        public static int Fold(List<int> list, int value, Func<int, int, int> func)
        {
            foreach(var item in list)
            {
                value = func(value, item);
            }
            return value;
        }
    }
}