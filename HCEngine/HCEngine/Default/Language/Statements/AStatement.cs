using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class for statements
    /// </summary>
    public abstract class AStatement : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.ChildrenNodes"/>
        /// </summary>
        public List<ISyntaxTreeItem> ChildrenNodes { get; set; } = new List<ISyntaxTreeItem>();

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/>
        /// </summary>
        public abstract IScriptExecution Execute(IExecutionScope scope);

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public abstract void Setup(ISourceReader reader, IExecutionScope scope);
    }
}
