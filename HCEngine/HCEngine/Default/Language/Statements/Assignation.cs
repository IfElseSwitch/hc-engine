using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute assignations
    /// </summary>
    public class Assignation : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.AssignationKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "Assignations should start with the assignation keyword");
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            var varexec = DefaultLanguageNodes.Variable.Execute(reader, scope, skipExec);
            string identifier = varexec.ExecuteNext() as string;
            if (string.IsNullOrEmpty(identifier))
                throw new OperationException(reader, "Identifier of assignation is null");
            reader.ReadNext();
            var opexec = DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);
            object lastValue = null;
            foreach (object o in opexec)
            {
                lastValue = o;
                if (!skipExec)
                    yield return o;
            }
            if (!skipExec)
            {
                scope[identifier] = lastValue;
                yield return null;
            }
        }
    }
}
