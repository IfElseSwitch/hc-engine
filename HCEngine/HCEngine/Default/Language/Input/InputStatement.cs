using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class representing input statements
    /// </summary>
    public class InputStatement : ISyntaxTreeItem
    {

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            if (DefaultLanguageNodes.Declaration.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.Declaration.Execute(reader, scope);

            if (DefaultLanguageNodes.ListOfDeclarations.IsStartOfNode(reader.LastKeyword, scope))
                return DefaultLanguageNodes.ListOfDeclarations.Execute(reader, scope);

            throw new SyntaxException(reader, "Not recognized as input statement");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.Declaration.IsStartOfNode(word, scope) || 
                DefaultLanguageNodes.ListOfDeclarations.IsStartOfNode(word, scope);
        }
    }
}
