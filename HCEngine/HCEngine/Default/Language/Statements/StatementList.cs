using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute statement lists
    /// </summary>
    public class StatementList : ISyntaxTreeItem
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
