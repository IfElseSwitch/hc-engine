using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Static class containing all of the default language keywords.
    /// </summary>
    /// <remarks>Should find better solution to allow diferent keywords for different engine instances.</remarks>
    public static class DefaultLanguageKeywords
    {
        public static string ListBeginSymbol { get; set; } = "(";
        public static string ListEndSymbol { get; set; } = ")";
        public static string VariableFirstSymbol { get; set; } = "$";
        public static string TypingKeyword { get; set; } = "is";
    }
}
