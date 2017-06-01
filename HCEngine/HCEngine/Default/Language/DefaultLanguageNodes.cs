using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public static class DefaultLanguageNodes
    {
        /// <summary>
        /// Syntax Node to use to read input statemens
        /// </summary>
        public static ISyntaxTreeItem InputStatement { get; set; } = new InputStatement();

        /// <summary>
        /// Syntax node to use to read input declarations.
        /// </summary>
        public static ISyntaxTreeItem Declaration { get; set; } = new InputDeclaration();

        /// <summary>
        /// Syntax node to use to read list of declarations.
        /// </summary>
        public static ISyntaxTreeItem ListOfDeclarations { get; set; } = new DeclarationList();

        /// <summary>
        /// Syntax node to use to read operations
        /// </summary>
        public static ISyntaxTreeItem Operation { get; set; } = new Operation();

        /// <summary>
        /// Syntax node to use to read variables.
        /// </summary>
        public static ISyntaxTreeItem Variable { get; set; } = new Variable();

        /// <summary>
        /// Syntax node to use to read constants
        /// </summary>
        public static ISyntaxTreeItem Constant { get; set; } = new Constant();

        /// <summary>
        /// Syntax node to use to read calls
        /// </summary>
        public static ISyntaxTreeItem Call { get; set; } = new Call();

    }
}
