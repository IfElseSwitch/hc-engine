using System.Collections;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    internal class EachDeclaration : ISyntaxTreeItem
    {
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            return new ScriptExecution(Exec(reader, scope, skipExec));
        }

        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.Variable.IsStartOfNode(word, scope);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            var varexec = DefaultLanguageNodes.Variable.Execute(reader, scope, true);
            var identifier = varexec.ExecuteNext() as string;
            reader.ReadNext();
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.EachKeyword))
                throw new SyntaxException(reader,
                    "In loop each declaration, the variable name should be folowed by the each keyword");
            reader.ReadNext();
            var sourceexec = DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);
            object lastValue = null;
            foreach (var o in sourceexec)
            {
                lastValue = o;
                yield return o;
            }
            if (lastValue is ICollection == false)
                throw new OperationException(reader, "Each loop source is not a collection");
            var source = (lastValue as ICollection).GetEnumerator();
            LoopCondition cond = () => Condition(identifier, source, scope);
            yield return cond;
        }

        private IEnumerable<object> Condition(string identifier, IEnumerator source, IExecutionScope scope)
        {
            if (!source.MoveNext())
            {
                yield return false;
                yield break;
            }
            scope[identifier] = source.Current;
            yield return null;
            yield return true;
        }
    }
}