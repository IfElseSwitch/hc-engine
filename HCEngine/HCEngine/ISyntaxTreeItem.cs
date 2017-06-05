namespace HCEngine
{
    /// <summary>
    ///     Interface for Syntax tree items.
    /// </summary>
    public interface ISyntaxTreeItem
    {
        /// <summary>
        ///     Logic for executing the node from source with a given scope
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader" /> for setting up the node.</param>
        /// <param name="scope">Scope of execution for calls and variables.</param>
        /// <param name="skipExec">Should we skip actually executing code and just read?</param>
        /// <returns>The execution object to control the execution.</returns>
        IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec);

        /// <summary>
        ///     Checks if the given word indicates the node type.
        /// </summary>
        /// <param name="word">Word to test</param>
        /// <param name="scope">current scope</param>
        /// <returns>true if the word should be interpreted, false otherwise.</returns>
        bool IsStartOfNode(string word, IExecutionScope scope);
    }
}