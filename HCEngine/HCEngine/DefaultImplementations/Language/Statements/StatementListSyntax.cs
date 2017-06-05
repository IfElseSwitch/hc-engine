using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class to execute statement lists
    /// </summary>
    public class StatementListSyntax : ISyntaxTreeItem
    {
        /// <summary>
        ///     <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)" />
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            return new ScriptExecution(Exec(reader, scope, skipExec));
        }

        /// <summary>
        ///     <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)" />
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            if (string.IsNullOrEmpty(word))
                return false;
            return word.Equals(DefaultLanguageKeywords.ListBeginSymbol);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "Lists should start with the list begin symbol.");
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            while (!reader.LastKeyword.Equals(DefaultLanguageKeywords.ListEndSymbol))
            {
                if (skipExec)
                {
                    reader.ReadNext();
                    continue;
                }
                var exec = DefaultLanguageNodes.Statement.Execute(reader, scope, skipExec);
                foreach (var o in exec)
                    yield return o;
                if (reader.ReadingComplete)
                    throw new SyntaxException(reader, "Unexpected end of file");
            }
            reader.ReadNext();
        }
    }
}