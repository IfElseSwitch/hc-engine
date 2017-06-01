using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class storing the default language classes
    /// </summary>
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
        /// Syntax node to use to read statements
        /// </summary>
        public static ISyntaxTreeItem Statement { get; set; } = new Statement();

        /// <summary>
        /// Syntax node to use to read lists of statements
        /// </summary>
        public static ISyntaxTreeItem ListOfStatements { get; set; } = new StatementList();

        /// <summary>
        /// Syntax node to use to read sections
        /// </summary>
        public static ISyntaxTreeItem Section { get; set; } = new Section();

        /// <summary>
        /// Syntax node to use to read ifs
        /// </summary>
        public static ISyntaxTreeItem If { get; set; } = new If();

        /// <summary>
        /// Syntax node to use to read loops
        /// </summary>
        public static ISyntaxTreeItem Loop { get; set; } = new Loop();

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
