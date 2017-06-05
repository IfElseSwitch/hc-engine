using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Syntax item to execute while declarations
    /// </summary>
    public class WhileDeclaration : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.WhileKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "While declaration should start with while keyword.");
            reader.ReadNext();
            var conditionReader = new LoopedSourceReader(reader);
            LoopCondition cond = () => Condition(conditionReader, scope, skipExec);
            yield return cond;
        }

        private IEnumerable<object> Condition(LoopedSourceReader reader, IExecutionScope scope, bool skipExec)
        {
            var exec = DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);
            object lastValue = null;
            foreach (var o in exec)
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