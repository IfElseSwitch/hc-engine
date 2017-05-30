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
        /// <param name="reader">
        ///   <see cref="ISourceReader" /> for setting up the node.</param>
        void Setup(ISourceReader reader);
        IScriptExecution Execute(IExecutionScope scope);
    }
}