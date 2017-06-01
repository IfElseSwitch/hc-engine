using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language.Statements
{
    /// <summary>
    /// Class representing a variable
    /// </summary>
    public class Variable : AOperation
    {
        /// <summary>
        /// Identifier of the variable in the scope.
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/> 
        /// </summary>
        public override IScriptExecution Execute(IExecutionScope scope)
        {
            return new ScriptExecution(Exec(scope));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public override void Setup(ISourceReader reader, IExecutionScope scope)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            string word = reader.LastKeyword;
            if (!word.StartsWith(DefaultLanguageKeywords.VariableFirstSymbol))
                throw new SyntaxException(reader, "Variable name does not start with $");
            Identifier = word;
            reader.ReadNext();
        }

        IEnumerator<object> Exec(IExecutionScope scope)
        {
            yield return scope[Identifier];
        }
    }
}
