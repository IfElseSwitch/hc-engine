using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute constants
    /// </summary>
    public class Constant : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            return new ScriptExecution(Exec(reader, scope));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            return true;
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
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
            }
            if (res == null)
                throw new SyntaxException(reader, string.Format("Unrecognized word : {0}", word));
            reader.ReadNext();
            yield return res;
        }
    }
}
