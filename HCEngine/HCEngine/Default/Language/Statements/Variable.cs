using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing a variable
    /// </summary>
    public class Variable : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            return new ScriptExecution(Exec(reader, scope, skipExec));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/>
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return word.StartsWith(DefaultLanguageKeywords.VariableFirstSymbol);
        }

        IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            string word = reader.LastKeyword;
            if (!IsStartOfNode(word, scope))
                throw new SyntaxException(reader, "Variable name does not start with $");
            string identifier = word;
            yield return identifier;
            object value = null;
            if (!skipExec)
                try
                {
                    value = scope[identifier];
                }
                catch(ScopeException se)
                {
                    throw new ScopeException(reader, se.Description);
                }
            reader.ReadNext();
            yield return value;
        }
    }
}
