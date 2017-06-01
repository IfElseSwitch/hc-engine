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
        /// <summary>
        /// Symbol for declaring the beginning of a list.
        /// </summary>
        public static string ListBeginSymbol { get; set; } = "(";

        /// <summary>
        /// Symbol for declaring the end of a list.
        /// </summary>
        public static string ListEndSymbol { get; set; } = ")";

        /// <summary>
        /// Symbol for declaring a variable.
        /// </summary>
        public static string VariableFirstSymbol { get; set; } = "$";

        /// <summary>
        /// Keyword for declaring a variable's type.
        /// </summary>
        public static string TypingKeyword { get; set; } = "is";

        /// <summary>
        /// Keyword for declaring an input section.
        /// </summary>
        public static string InputKeyword { get; set; } = "input";
    }
}
