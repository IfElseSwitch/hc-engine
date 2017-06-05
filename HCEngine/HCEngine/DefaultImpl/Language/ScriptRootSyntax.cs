using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    /// Class to execute scripts
    /// </summary>
    public class ScriptRootSyntax : ISyntaxTreeItem
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
            return true;
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            IDictionary<string, Type> pmap = new Dictionary<string, Type>();
            if (DefaultLanguageNodes.InputSection.IsStartOfNode(reader.LastKeyword, scope))
            {
                var inputexec = DefaultLanguageNodes.InputSection.Execute(reader, scope, skipExec);
                object lastValue = null;
                foreach (object o in inputexec)
                    lastValue = o;
                if (lastValue is IDictionary<string, Type> == false)
                    throw new OperationException(reader, "Input section does not yield parameters map.");
                pmap = lastValue as IDictionary<string, Type>;
            }
            yield return pmap;

            foreach (var kvp in pmap)
            {
                if (!scope.Contains(kvp.Key))
                    throw new OperationException(reader, string.Format("Execution scope does not contain input parameter {0}", kvp.Key));
                if (!kvp.Value.IsAssignableFrom(scope[kvp.Key].GetType()))
                    throw new OperationException(reader, string.Format("Provided input parameter {0} wrong type. Expected {1}got {2}", kvp.Key, kvp.Value, scope[kvp.Key].GetType()));
            }
            IExecutionScope scriptScope = scope.MakeSubScope();
            while (!reader.ReadingComplete)
            {
                var exec = DefaultLanguageNodes.Statement.Execute(reader, scriptScope, skipExec);
                foreach (object o in exec)
                    yield return o;
            }

        }
    }
}
