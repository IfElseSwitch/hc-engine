namespace HCEngine.Default.Built_in
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
        public static int[] Range(int max)
        {
            int[] res = new int[max];
            for (int i = 0; i < max; ++i)
                res[i] = i;
            return res;
        }
    }
}
