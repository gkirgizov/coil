using System;
using System.Collections.Generic;

namespace hw1
{
    public interface IIterable<T>
    {
        /// <summary>
        /// Returns iterator for this IIterable object.
        /// </summary>
        /// <param name="parentObject"></param>
        /// <returns></returns>
        IIterator<T> ReturnIterator();
    }
}
