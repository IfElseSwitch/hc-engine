using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class representing an Input section.
    /// </summary>
    public class InputSection : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.InputKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.InputKeyword))
                throw new SyntaxException(reader, "Input sections should start with the input keyword");
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            IDictionary<string, Type> parametersMap = new Dictionary<string, Type>();
            var exec = DefaultLanguageNodes.InputStatement.Execute(reader, scope, skipExec);
            var pmap = exec.ExecuteNext() as IDictionary<string, Type>;
            foreach (var kvp in pmap)
                parametersMap.Add(kvp);
            yield return parametersMap;
        }
    }
}