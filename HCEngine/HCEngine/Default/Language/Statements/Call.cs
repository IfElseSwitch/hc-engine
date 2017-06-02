using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class for call operations
    /// </summary>
    public class Call : ISyntaxTreeItem
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
            return scope.Contains(word) && scope.IsOfType<MethodInfo>(word);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            string word = reader.LastKeyword;
            var method = scope[word] as MethodInfo;
            if (method == null)
                throw new SyntaxException(reader, string.Format("{0} is not a call", word));
            reader.ReadNext();
            var parameters = method.GetParameters();
            object[] args = new object[parameters.Length];
            int i = 0;
            foreach (var param in parameters)
            {
                if (reader.ReadingComplete)
                    throw new SyntaxException(reader, "Unexpected end of file");
                var exec = DefaultLanguageNodes.Operation.Execute(reader, scope, skipExec);
                object lastValue = null;
                foreach(object o in exec)
                {
                    lastValue = o;
                    if (!skipExec)
                        yield return o;
                }
                if (!skipExec && !param.ParameterType.IsAssignableFrom(lastValue.GetType()))
                    throw new OperationException(reader, string.Format("Wrong parameter for argument {0} of call {1}", param.Name, method.Name));
                args[i++] = lastValue;
            }
            if (!skipExec)
                yield return method.Invoke(null, args);
        }
    }
}
