using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class representing a List of declarations.
    /// </summary>
    public class DeclarationList : ISyntaxTreeItem
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

            IDictionary<string, Type> parametersMap = new Dictionary<string, Type>();

            while (!reader.LastKeyword.Equals(DefaultLanguageKeywords.ListEndSymbol))
            {
                var declaration = new InputDeclaration();
                var exec = DefaultLanguageNodes.Declaration.Execute(reader, scope, skipExec);
                var o = exec.ExecuteNext();
                var pmap = o as IDictionary<string, Type>;
                if (reader.ReadingComplete)
                    throw new SyntaxException(reader, "Unexpected end of file");
                if (pmap == null)
                    throw new SyntaxException(reader, "No parameters");
                foreach (var kvp in pmap)
                    parametersMap.Add(kvp);
            }
            reader.ReadNext();
            yield return parametersMap;
        }
    }
}