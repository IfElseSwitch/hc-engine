using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute sections
    /// </summary>
    public class Section : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            if (DefaultLanguageNodes.If.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.If.Execute(reader, scope);

            if (DefaultLanguageNodes.Loop.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Loop.Execute(reader, scope);

            throw new SyntaxException(reader, "Not recognized as section");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/> 
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.If.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Loop.IsStartOfNode(word, scope);
        }
    }
}
