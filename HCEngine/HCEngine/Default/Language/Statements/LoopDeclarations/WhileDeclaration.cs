using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public class WhileDeclaration : ISyntaxTreeItem
    {
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            return new ScriptExecution(Exec(reader, scope, skipExec));
        }

        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return word.Equals(DefaultLanguageKeywords.WhileKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "While declaration should start with while keyword.");
            reader.ReadNext();
            LoopedSourceReader conditionReader = new LoopedSourceReader(reader);
            LoopCondition cond = () => Condition(conditionReader, scope, skipExec);
            yield return cond;
        }

        IEnumerable<object> Condition(LoopedSourceReader reader, IExecutionScope scope, bool skipExec)
        {
            var exec = DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);
            object lastValue = null;
            foreach (object o in exec)
            {
                lastValue = o;
                yield return o;
            }
            reader.Reset();
            if (lastValue is bool == false)
                throw new OperationException(reader, "While condition is not bool");
            yield return (bool) lastValue;
        }
    }
}
