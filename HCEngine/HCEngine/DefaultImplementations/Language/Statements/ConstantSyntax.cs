using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class to execute constants
    /// </summary>
    public class ConstantSyntax : ISyntaxTreeItem
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
            if (scope == null)
                return false;
            foreach (var id in scope.KnownIdentifiers)
            {
                if (!id.StartsWith("cr:"))
                    continue;
                var cr = scope[id] as IConstantReader;
                object res;
                if (cr.TryRead(word, out res))
                    return true;
            }
            return false;
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            object res = null;
            var word = reader.LastKeyword;
            foreach (var id in scope.KnownIdentifiers)
            {
                if (!id.StartsWith("cr:"))
                    continue;
                var cr = scope[id] as IConstantReader;
                if (cr.TryRead(word, out res))
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