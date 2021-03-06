﻿using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class representing a variable
    /// </summary>
    public class VariableSyntax : ISyntaxTreeItem
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
            return word.StartsWith(DefaultLanguageKeywords.VariableFirstSymbol);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            var word = reader.LastKeyword;
            if (!IsStartOfNode(word, scope))
                throw new SyntaxException(reader, "Variable name does not start with $");
            var identifier = word;
            yield return identifier;
            object value = null;
            if (!skipExec)
                try
                {
                    value = scope[identifier];
                }
                catch (ScopeException se)
                {
                    throw new ScopeException(reader, se.Description);
                }
            reader.ReadNext();
            yield return value;
        }
    }
}