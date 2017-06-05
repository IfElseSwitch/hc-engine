namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class storing the default language classes
    /// </summary>
    public static class DefaultLanguageNodes
    {
        /// <summary>
        ///     Syntax node to read scripts
        /// </summary>
        public static ISyntaxTreeItem ScriptRoot { get; set; } = new ScriptRootSyntax();

        /// <summary>
        ///     Syntax Node to use to read input sections
        /// </summary>
        public static ISyntaxTreeItem InputSection { get; set; } = new InputSection();

        /// <summary>
        ///     Syntax Node to use to read input statemens
        /// </summary>
        public static ISyntaxTreeItem InputStatement { get; set; } = new InputStatement();

        /// <summary>
        ///     Syntax node to use to read input declarations.
        /// </summary>
        public static ISyntaxTreeItem Declaration { get; set; } = new InputDeclaration();

        /// <summary>
        ///     Syntax node to use to read list of declarations.
        /// </summary>
        public static ISyntaxTreeItem ListOfDeclarations { get; set; } = new DeclarationList();

        /// <summary>
        ///     Syntax node to use to read statements
        /// </summary>
        public static ISyntaxTreeItem Statement { get; set; } = new StatementSyntax();

        /// <summary>
        ///     Syntax node to use to read lists of statements
        /// </summary>
        public static ISyntaxTreeItem ListOfStatements { get; set; } = new StatementListSyntax();

        /// <summary>
        ///     Syntax node to use to read sections
        /// </summary>
        public static ISyntaxTreeItem Section { get; set; } = new SectionSyntax();

        /// <summary>
        ///     Syntax node to use to read ifs
        /// </summary>
        public static ISyntaxTreeItem If { get; set; } = new IfSyntax();

        /// <summary>
        ///     Syntax node to use to read loops
        /// </summary>
        public static ISyntaxTreeItem Loop { get; set; } = new LoopSyntax();

        /// <summary>
        ///     Syntax node to use to read loops
        /// </summary>
        public static ISyntaxTreeItem LoopDeclaration { get; set; } = new LoopDeclaration();

        /// <summary>
        ///     Syntax node to use to read Each declarations
        /// </summary>
        public static ISyntaxTreeItem EachDeclaration { get; set; } = new EachDeclaration();

        /// <summary>
        ///     Syntax node to use to read While declarations
        /// </summary>
        public static ISyntaxTreeItem WhileDeclaration { get; set; } = new WhileDeclaration();

        /// <summary>
        ///     Syntax node to use to read operations
        /// </summary>
        public static ISyntaxTreeItem Operation { get; set; } = new OperationSyntax();

        /// <summary>
        ///     Syntax node to use to read variables.
        /// </summary>
        public static ISyntaxTreeItem Variable { get; set; } = new VariableSyntax();

        /// <summary>
        ///     Syntax node to use to read constants
        /// </summary>
        public static ISyntaxTreeItem Constant { get; set; } = new ConstantSyntax();

        /// <summary>
        ///     Syntax node to use to read calls
        /// </summary>
        public static ISyntaxTreeItem Call { get; set; } = new CallSyntax();

        /// <summary>
        ///     Syntax node to use to read assignations
        /// </summary>
        public static ISyntaxTreeItem Assignation { get; set; } = new AssignationSyntax();
    }
}