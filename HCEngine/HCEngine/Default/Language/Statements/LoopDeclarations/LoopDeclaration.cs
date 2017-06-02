using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public class LoopDeclaration : ISyntaxTreeItem
    {
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            string word = reader.LastKeyword;
            if (DefaultLanguageNodes.WhileDeclaration.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.WhileDeclaration.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.EachDeclaration.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.EachDeclaration.Execute(reader, scope, skipExec);

            throw new SyntaxException(reader, "Not recognized as loop declaration");
        }

        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.EachDeclaration.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.WhileDeclaration.IsStartOfNode(word, scope);
        }
    }
}
