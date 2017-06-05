using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    ///     Static class exposing built-in calls
    /// </summary>
    public static class Calls
    {
        /// <summary>
        ///     Built-in call that creates a list filled with integers from 0 (included) to max (excluded).
        /// </summary>
        /// <param name="max">Length of the array</param>
        /// <returns>List [0..max[</returns>
        [ExposedCall]
        public static IList<int> Range(int max)
        {
            var res = new List<int>();
            for (var i = 0; i < max; ++i)
                res.Add(i);
            return res;
        }

        /// <summary>
        ///     Built-in call that checks if a is strictly inferior to b.
        /// </summary>
        /// <param name="comparable1">Comparable that should be inferior</param>
        /// <param name="comparable2">Comparable that should be superior</param>
        /// <returns>a inferior to b</returns>
        [ExposedCall(NameOverride = "inf")]
        public static bool Inferior(IComparable comparable1, IComparable comparable2)
        {
            if (comparable1 == null)
                return false;
            return comparable1.CompareTo(comparable2) < 0;
        }

        /// <summary>
        ///     Built-in call that checks if a is strictly superior to b.
        /// </summary>
        /// <param name="comparable1">Comparable that should be superior</param>
        /// <param name="comparable2">Comparable that should be inferior</param>
        /// <returns>a superior to b</returns>
        [ExposedCall(NameOverride = "sup")]
        public static bool Superior(IComparable comparable1, IComparable comparable2)
        {
            if (comparable1 == null)
                return false;
            return comparable1.CompareTo(comparable2) > 0;
        }

        /// <summary>
        ///     Built-in call that checks if a is equal to b.
        /// </summary>
        /// <param name="comparable1">first Comparable</param>
        /// <param name="comparable2">second Comparable</param>
        /// <returns>a == b</returns>
        [ExposedCall(NameOverride = "eq")]
        public static bool Equals(IComparable comparable1, IComparable comparable2)
        {
            if (comparable1 == null)
                if (comparable2 == null)
                    return true;
                else
                    return false;
            return comparable1.CompareTo(comparable2) == 0;
        }

        /// <summary>
        ///     Built-in call that checks if a is not equal to b.
        /// </summary>
        /// <param name="comparable1">first Comparable</param>
        /// <param name="comparable2">second Comparable</param>
        /// <returns>a != b</returns>
        [ExposedCall(NameOverride = "dif")]
        public static bool Differs(IComparable comparable1, IComparable comparable2)
        {
            return !Equals(comparable1, comparable2);
        }

        /// <summary>
        ///     Built-in call that adds integers a and b.
        /// </summary>
        /// <param name="number1">first integer</param>
        /// <param name="number2">Second integer</param>
        /// <returns>a + b</returns>
        [ExposedCall]
        public static int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        ///     Built-in call that subtracts integers a and b.
        /// </summary>
        /// <param name="number1">first integer</param>
        /// <param name="number2">Second integer</param>
        /// <returns>a - b</returns>
        [ExposedCall(NameOverride = "sub")]
        public static int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        ///     Built-in call that multiplies integers a and b.
        /// </summary>
        /// <param name="number1">first integer</param>
        /// <param name="number2">Second integer</param>
        /// <returns>a * b</returns>
        [ExposedCall(NameOverride = "mul")]
        public static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        ///     Built-in call that divides integers a and b.
        ///     The result will be the integer part of the division.
        /// </summary>
        /// <param name="number1">first integer</param>
        /// <param name="number2">Second integer</param>
        /// <returns>a / b</returns>
        [ExposedCall(NameOverride = "sub")]
        public static int Divide(int number1, int number2)
        {
            return number1 / number2;
        }

        /// <summary>
        ///     Built-in call that calculates the remainder of the division of a number by another.
        /// </summary>
        /// <param name="number">number to divide</param>
        /// <param name="modulo">Divider</param>
        /// <returns>Remainder of number / modulo (number % modulo)</returns>
        [ExposedCall(NameOverride = "mod")]
        public static int Modulo(int number, int modulo)
        {
            return number % modulo;
        }
    }
}