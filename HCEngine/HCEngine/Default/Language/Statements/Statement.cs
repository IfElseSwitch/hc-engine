using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class for statements
    /// </summary>
    public abstract class Statement : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public abstract IScriptExecution Execute(ISourceReader reader, IExecutionScope scope);

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            throw new NotImplementedException();
        }
    }
}
