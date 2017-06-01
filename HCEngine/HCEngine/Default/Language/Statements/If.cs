﻿using System;
using System.Collections.Generic;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class for executing ifs
    /// </summary>
    public class If : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.IfKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            throw new NotImplementedException();
        }
    }
}
