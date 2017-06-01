using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class for statements
    /// </summary>
    public class Statement : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }
    }
}
