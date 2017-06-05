using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    /// Syntax item to execute loop declarations
    /// </summary>
    public class LoopDeclaration : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader == null)
                return null;
            string word = reader.LastKeyword;
            if (DefaultLanguageNodes.WhileDeclaration.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.WhileDeclaration.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.EachDeclaration.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.EachDeclaration.Execute(reader, scope, skipExec);

            throw new SyntaxException(reader, "Not recognized as loop declaration");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.EachDeclaration.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.WhileDeclaration.IsStartOfNode(word, scope);
        }
    }
}
