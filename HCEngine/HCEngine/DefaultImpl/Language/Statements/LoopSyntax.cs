using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    /// Delegate used by loop declarations to generate the execution of the condition. 
    /// The last object yielded must be a bool.
    /// </summary>
    /// <returns></returns>
    public delegate IEnumerable<object> LoopCondition();

    /// <summary>
    /// Class to execute loops
    /// </summary>
    public class LoopSyntax : ISyntaxTreeItem
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
            if (string.IsNullOrEmpty(word))
                return false;
            return word.Equals(DefaultLanguageKeywords.LoopKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "Loop section should start with loop keyword");
            reader.ReadNext();
            IExecutionScope loopScope = scope.MakeSubScope();
            var declarationexec = DefaultLanguageNodes.LoopDeclaration.Execute(reader, loopScope, skipExec);
            object lastValue = null;
            foreach(object o in declarationexec)
            {
                lastValue = o;
                if (o is LoopCondition == false)
                    yield return o;
            }
            if (lastValue is LoopCondition == false)
                throw new OperationException(reader, "No condition generated for loop");
            LoopCondition condition = lastValue as LoopCondition;
            LoopedSourceReader loopedReader = new LoopedSourceReader(reader);
            loopedReader.ForgetFirst();
            bool first = true;
            while (true)
            {
                var condexec = condition();
                lastValue = null;
                foreach(object o in condexec)
                {
                    lastValue = o;
                    if (!skipExec)
                        yield return o;
                }
                if (first)
                {
                    loopedReader.AddSnapshot();
                    first = false;
                }
                if (lastValue is bool == false)
                    throw new OperationException(loopedReader, "Invalid returned value by condition");
                bool doLoop = (bool) lastValue;
                if (!doLoop)
                    break;
                var exec = DefaultLanguageNodes.Statement.Execute(loopedReader, loopScope, skipExec);
                foreach (object o in exec)
                    if (!skipExec)
                        yield return o;
                loopedReader.Reset();
            }
        }
    }
}
