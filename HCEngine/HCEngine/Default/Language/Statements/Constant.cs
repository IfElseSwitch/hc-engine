using System.Collections.Generic;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute constants
    /// </summary>
    public class Constant : ISyntaxTreeItem
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
            foreach (string id in scope.KnownIdentifiers)
            {
                if (!id.StartsWith("cr:"))
                    continue;
                IConstantReader cr = scope[id] as IConstantReader;
                object res;
                if (cr.Try(word, out res))
                    return true;
            }
            return false;
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            object res = null;
            string word = reader.LastKeyword;
            foreach (string id in scope.KnownIdentifiers)
            {
                if (!id.StartsWith("cr:"))
                    continue;
                IConstantReader cr = scope[id] as IConstantReader;
                if (cr.Try(word, out res))
                    break;
                res = null;
            }
            if (res == null)
                throw new SyntaxException(reader, string.Format("Unrecognized word : {0}", word));
            reader.ReadNext();
            yield return res;
        }
    }
}
