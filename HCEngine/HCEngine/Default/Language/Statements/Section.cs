﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class to execute sections
    /// </summary>
    public class Section : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            if (DefaultLanguageNodes.If.IsStartOfNode(reader.LastKeyword, scope))
                DefaultLanguageNodes.If.Execute(reader, scope);

            if (DefaultLanguageNodes.Loop.IsStartOfNode(reader.LastKeyword, scope))
                DefaultLanguageNodes.Loop.Execute(reader, scope);
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)"/> 
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.If.IsStartOfNode(word, scope) ||
                DefaultLanguageNodes.Loop.IsStartOfNode(word, scope);
        }
    }
}
