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
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (DefaultLanguageNodes.If.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.If.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Loop.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Loop.Execute(reader, scope, skipExec);

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
