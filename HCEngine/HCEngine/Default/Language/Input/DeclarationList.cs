using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing a List of declarations.
    /// </summary>
    public class DeclarationList : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            return new ScriptExecution(Exec(reader, scope));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return word.Equals(DefaultLanguageKeywords.ListBeginSymbol);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
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
                InputDeclaration declaration = new InputDeclaration();
                var exec = DefaultLanguageNodes.Declaration.Execute(reader, scope);
                object o = exec.ExecuteNext();
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
