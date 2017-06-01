﻿using System;
using System.Collections.Generic;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute loops
    /// </summary>
    public class Loop : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            return new ScriptExecution(Exec(reader, scope));
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/> 
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return word.Equals(DefaultLanguageKeywords.LoopKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }
    }
}
