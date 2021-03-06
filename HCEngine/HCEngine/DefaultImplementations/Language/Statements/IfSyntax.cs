﻿using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class for executing ifs
    /// </summary>
    public class IfSyntax : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.IfKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "If section should start with if keyword");
            reader.ReadNext();
            var ifScope = scope.MakeSubScope();
            var condexec = DefaultLanguageNodes.Operation.Execute(reader, ifScope, skipExec);
            object lastResult = null;
            foreach (var o in condexec)
            {
                lastResult = o;
                if (!skipExec)
                    yield return o;
            }
            if (lastResult is bool == false)
                throw new OperationException(reader, "if condition is not boolean value");
            var cond = (bool) lastResult;
            var thenexec = DefaultLanguageNodes.Statement.Execute(reader, ifScope, !cond);
            foreach (var o in thenexec)
                if (cond)
                    yield return o;
            if (reader.ReadingComplete)
                yield break;
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.ElseKeyword))
                yield break;
            reader.ReadNext();
            var elseexec = DefaultLanguageNodes.Statement.Execute(reader, ifScope, cond);
            foreach (var o in elseexec)
                if (!cond)
                    yield return o;
        }
    }
}