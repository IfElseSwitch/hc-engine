using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    /// Base class for statements
    /// </summary>
    public class StatementSyntax : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader == null)
                return null;

            if (DefaultLanguageNodes.ListOfStatements.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.ListOfStatements.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Section.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Section.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Operation.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);

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
