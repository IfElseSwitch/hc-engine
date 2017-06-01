using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class for Operation item
    /// </summary>
    public class Operation : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            string word = reader.LastKeyword;
            if (DefaultLanguageNodes.Call.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Call.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Variable.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Variable.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Constant.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Constant.Execute(reader, scope, skipExec);

            throw new SyntaxException(reader, "Not recognized as operation");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.Call.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Variable.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Constant.IsStartOfNode(word, scope);
        }
    }
}
