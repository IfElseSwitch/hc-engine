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
            if (DefaultLanguageNodes.Declaration.IsStartOfNode(reader.LastKeyword))
                return DefaultLanguageNodes.Declaration.Execute(reader, scope);

            if (DefaultLanguageNodes.ListOfDeclarations.IsStartOfNode(reader.LastKeyword))
                return DefaultLanguageNodes.ListOfDeclarations.Execute(reader, scope);

            throw new SyntaxException(reader, "Not recognized as input statement");
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            return DefaultLanguageNodes.Declaration.IsStartOfNode(word) || 
                DefaultLanguageNodes.ListOfDeclarations.IsStartOfNode(word);
        }
    }
}
