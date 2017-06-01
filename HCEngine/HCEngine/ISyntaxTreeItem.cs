using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine
{
    /// <summary>
    /// Interface for Syntax tree items.
    /// </summary>
    public interface ISyntaxTreeItem
    {
        /// <summary>
        /// Logic for executing the node from source with a given scope
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader" /> for setting up the node.</param>
        /// <param name="scope">Scope of execution for calls and variables.</param>
        /// <returns>The execution object to control the execution.</returns>
        IScriptExecution Execute(ISourceReader reader, IExecutionScope scope);

        /// <summary>
        /// Checks if the given word indicates the node type.
        /// </summary>
        /// <param name="word">Word to test</param>
        /// <returns>true if the word should be interpreted, false otherwise.</returns>
        bool IsStartOfNode(string word);
    }
}