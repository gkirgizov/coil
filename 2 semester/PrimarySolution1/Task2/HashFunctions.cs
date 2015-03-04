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
    }
}
