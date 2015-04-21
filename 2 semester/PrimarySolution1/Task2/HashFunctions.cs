using System;

namespace Task2
{
    /// <summary>
    /// Contains hash functions
    /// </summary>
    public class HashFunctions
    {
        /// <summary>
        /// Return hash of the string
        /// </summary>
        public static int StringHashFunction1(string hashedData)
        {
            int hash = 0;
            foreach(char token in hashedData)
            {
                hash += (int)token;
            }
            return hash;
        }

        /// <summary>
        /// Return positive hash of any data of any type
        /// </summary>
        public static int UniversalHashFunction<T>(T hashedData)
        {
            return Math.Abs(hashedData.GetHashCode());
        }
    }
}
