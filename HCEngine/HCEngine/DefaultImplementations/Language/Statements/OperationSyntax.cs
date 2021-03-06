﻿namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Base class for Operation item
    /// </summary>
    public class OperationSyntax : ISyntaxTreeItem
    {
        /// <summary>
        ///     <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)" />
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (reader == null)
                return null;
            var word = reader.LastKeyword;

            if (DefaultLanguageNodes.Assignation.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Assignation.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Call.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Call.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Variable.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Variable.Execute(reader, scope, skipExec);

            if (DefaultLanguageNodes.Constant.IsStartOfNode(word, scope))
                return DefaultLanguageNodes.Constant.Execute(reader, scope, skipExec);

            throw new SyntaxException(reader, "Not recognized as operation");
        }

        /// <summary>
        ///     <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)" />
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.Call.IsStartOfNode(word, scope) ||
                   DefaultLanguageNodes.Assignation.IsStartOfNode(word, scope) ||
                   DefaultLanguageNodes.Variable.IsStartOfNode(word, scope) ||
                   DefaultLanguageNodes.Constant.IsStartOfNode(word, scope);
        }
    }
}