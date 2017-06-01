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
            if (DefaultLanguageNodes.ListOfStatements.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.ListOfStatements.Execute(reader, scope);

            if (DefaultLanguageNodes.Section.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Section.Execute(reader, scope);

            if (DefaultLanguageNodes.Operation.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Operation.Execute(reader, scope);

            throw new SyntaxException(reader, "Not recognized as statement");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.ListOfStatements.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Section.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Operation.IsStartOfNode(word, scope);
        }
    }
}
