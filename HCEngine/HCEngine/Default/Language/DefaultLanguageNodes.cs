using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public static class DefaultLanguageNodes
    {
        public static ISyntaxTreeItem InputStatement { get; set; } = new InputStatement();

        /// <summary>
        /// Syntax node to use to read declarations.
        /// </summary>
        public static ISyntaxTreeItem Declaration { get; set; } = new InputDeclaration();

        /// <summary>
        /// Syntax node to use to read list of declarations.
        /// </summary>
        public static ISyntaxTreeItem ListOfDeclarations { get; set; } = new DeclarationList();

        /// <summary>
        /// Syntax node to use to read variables.
        /// </summary>
        public static ISyntaxTreeItem Variable { get; set; } = new Variable();
    }
}
