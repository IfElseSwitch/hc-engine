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

        IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            string word = reader.LastKeyword;
            if (!word.StartsWith(DefaultLanguageKeywords.VariableFirstSymbol))
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

        ///// <summary>
        ///// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/> 
        ///// </summary>
        //public override IScriptExecution Execute(IExecutionScope scope)
        //{
        //    return new ScriptExecution(Exec(scope));
        //}

        ///// <summary>
        ///// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/>
        ///// </summary>
        //public override void Setup(ISourceReader reader, IExecutionScope scope)
        //{
        //}

        //IEnumerator<object> Exec(IExecutionScope scope)
        //{
        //    yield return scope[Identifier];
        //}
    }
}
