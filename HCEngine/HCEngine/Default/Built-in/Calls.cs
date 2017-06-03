using System;
using System.Collections.Generic;

namespace HCEngine.Default
{
    /// <summary>
    /// Static class exposing built-in calls
    /// </summary>
    static public class Calls
    {
        /// <summary>
        /// Built-in call that creates a array filled with integers from 0 (included) to max (excluded).
        /// </summary>
        /// <param name="max">Length of the array</param>
        /// <returns>Array [0..max[</returns>
        [ExposedCall]
        public static List<int> Range(int max)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < max; ++i)
                res.Add(i);
            return res;
        }

        /// <summary>
        /// Built-in call that checks if a is strictly inferior to b.
        /// </summary>
        /// <param name="a">Comparable that should be inferior</param>
        /// <param name="b">Comparable that should be superior</param>
        /// <returns>a inferior to b</returns>
        [ExposedCall]
        public static bool Inf(IComparable a, IComparable b)
        {
            return a.CompareTo(b) < 0;
        }

        /// <summary>
        /// Built-in call that checks if a is strictly superior to b.
        /// </summary>
        /// <param name="a">Comparable that should be superior</param>
        /// <param name="b">Comparable that should be inferior</param>
        /// <returns>a superior to b</returns>
        [ExposedCall]
        public static bool Sup(IComparable a, IComparable b)
        {
            return a.CompareTo(b) > 0;
        }

        /// <summary>
        /// Built-in call that checks if a is equal to b.
        /// </summary>
        /// <param name="a">first Comparable</param>
        /// <param name="b">second Comparable</param>
        /// <returns>a == b</returns>
        [ExposedCall]
        public static bool Eq(IComparable a, IComparable b)
        {
            return a.CompareTo(b) == 0;
        }

        /// <summary>
        /// Built-in call that adds integers a and b.
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">Second integer</param>
        /// <returns>a + b</returns>
        [ExposedCall]
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
