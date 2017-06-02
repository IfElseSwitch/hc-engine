namespace HCEngine.Default
{
    /// <summary>
    /// Class exposing strings
    /// </summary>
    [ExposedType(LinkToType = typeof(string), NameOverride = "String", ConstantReaderType = typeof(StringReader))]
    public class StringLink
    {
        class StringReader : IConstantReader
        {
            public bool Try(string word, out object instance)
            {
                instance = null;
                if (!word.StartsWith("\"") || !word.EndsWith("\""))
                    return false;
                instance = word.Substring(1, word.Length - 2);
                return true;
            }
        }
    }
    /// <summary>
    /// Class exposing ints
    /// </summary>
    [ExposedType(LinkToType = typeof(int), NameOverride = "Int", ConstantReaderType = typeof(IntReader))]
    public class IntLink
    {
        class IntReader : IConstantReader
        {
            public bool Try(string word, out object instance)
            {
                int i;
                bool res = int.TryParse(word, out i);
                instance = i;
                return res;
            }
        }
    }

    /// <summary>
    /// Class exposing bools
    /// </summary>
    [ExposedType(LinkToType = typeof(bool), NameOverride = "Bool", ConstantReaderType = typeof(BoolReader))]
    public class BoolLink
    {
        class BoolReader : IConstantReader
        {
            public bool Try(string word, out object instance)
            {
                bool b;
                bool res = bool.TryParse(word, out b);
                instance = b;
                return res;
            }
        }
    }
}

