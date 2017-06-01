using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class representing input statements
    /// </summary>
    public class AInputStatement : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            throw new NotImplementedException();
        }
    }
}
