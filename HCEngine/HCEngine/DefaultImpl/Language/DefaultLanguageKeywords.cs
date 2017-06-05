using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations.Language
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

        /// <summary>
        /// Keyword for declaring a loop.
        /// </summary>
        public static string LoopKeyword { get; set; } = "loop";

        /// <summary>
        /// Keyword for declaring a while loop.
        /// </summary>
        public static string WhileKeyword { get; set; } = "while";

        /// <summary>
        /// Keyword for declaring a each loop.
        /// </summary>
        public static string EachKeyword { get; set; } = "in";

        /// <summary>
        /// Keyword for declaring a if section.
        /// </summary>
        public static string IfKeyword { get; set; } = "if";

        /// <summary>
        /// Keyword for declaring a else block of a if section.
        /// </summary>
        public static string ElseKeyword { get; set; } = "else";

        /// <summary>
        /// Keyword for declaring an assignation.
        /// </summary>
        public static string AssignationKeyword { get; set; } = "set";
    }
}
