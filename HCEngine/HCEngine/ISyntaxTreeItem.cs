using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine
{
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

        /// <summary>
        /// Logic for executing the item, given a scope.
        /// </summary>
        /// <param name="scope">Current scope for the execution.</param>
        void Execute(IExecutionScope scope);
    }
}