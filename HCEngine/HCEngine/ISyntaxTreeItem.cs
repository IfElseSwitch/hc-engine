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
        /// List of all children nodes
        /// </summary>
        List<ISyntaxTreeItem> ChildrenNodes { get; set; }

        /// <summary>
        /// Logic for setting up the node from a <see cref="ISourceReader" /> .
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader" /> for setting up the node.</param>
        /// <param name="scope"><see cref="IExecutionScope"/> for reading calls and types names </param>
        void Setup(ISourceReader reader, IExecutionScope scope);

        /// <summary>
        /// Logic for executing the node with a given scope
        /// </summary>
        /// <param name="scope">Scope of execution for calls and variables.</param>
        /// <returns>The execution object to control the execution.</returns>
        IScriptExecution Execute(IExecutionScope scope);
    }
}