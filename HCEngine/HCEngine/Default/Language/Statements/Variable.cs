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
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            return new ScriptExecution(Exec(reader, scope));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            return word.StartsWith(DefaultLanguageKeywords.VariableFirstSymbol);
        }

        IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            string word = reader.LastKeyword;
            if (!IsStartOfNode(word))
                throw new SyntaxException(reader, "Variable name does not start with $");
            string identifier = word;
            yield return identifier;
            object value = null;
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
