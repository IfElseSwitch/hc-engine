

using System.Collections.Generic;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    ///     Class exposing strings
    /// </summary>
    [ExposedType(LinkToType = typeof(string), NameOverride = "String", ConstantReaderType = typeof(StringReader))]
    public static class StringLink
    {
        private class StringReader : IConstantReader
        {
            public bool TryRead(string word, out object instance)
            {
                instance = null;
                if (string.IsNullOrEmpty(word))
                    return false;
                if (!word.StartsWith("\"") || !word.EndsWith("\""))
                    return false;
                instance = word.Substring(1, word.Length - 2);
                return true;
            }
        }
    }

    /// <summary>
    ///     Class exposing ints
    /// </summary>
    [ExposedType(LinkToType = typeof(int), NameOverride = "Int", ConstantReaderType = typeof(IntReader))]
    public static class IntLink
    {
        private class IntReader : IConstantReader
        {
            public bool TryRead(string word, out object instance)
            {
                int i;
                var res = int.TryParse(word, out i);
                instance = i;
                return res;
            }
        }
    }

    /// <summary>
    ///     Class exposing bools
    /// </summary>
    [ExposedType(LinkToType = typeof(bool), NameOverride = "Bool", ConstantReaderType = typeof(BoolReader))]
    public static class BoolLink
    {
        private class BoolReader : IConstantReader
        {
            public bool TryRead(string word, out object instance)
            {
                bool b;
                var res = bool.TryParse(word, out b);
                instance = b;
                return res;
            }
        }
    }

    [ExposedType(NameOverride = "List", Generic = true, LinkToType = typeof(List<object>))]
    public static class ListLink
    {
    }

}