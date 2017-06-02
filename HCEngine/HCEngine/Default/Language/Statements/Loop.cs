﻿using System;
using System.Collections.Generic;

namespace HCEngine.Default.Language
{
    public delegate IEnumerable<object> LoopCondition();
    /// <summary>
    /// Class to execute loops
    /// </summary>
    public class Loop : ISyntaxTreeItem
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
            return word.Equals(DefaultLanguageKeywords.LoopKeyword);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            if (!IsStartOfNode(reader.LastKeyword, scope))
                throw new SyntaxException(reader, "Loop section should start with loop keyword");
            reader.ReadNext();
            IExecutionScope loopScope = scope.MakeSubScope();
            var declarationexec = DefaultLanguageNodes.LoopDeclaration.Execute(reader, loopScope, skipExec);
            object lastValue = null;
            foreach(object o in declarationexec)
            {
                lastValue = o;
                yield return o;
            }
            if (lastValue is LoopCondition == false)
                throw new OperationException(reader, "No condition generated for loop");
            LoopCondition condition = lastValue as LoopCondition;
            LoopedSourceReader loopedReader = new LoopedSourceReader(reader);

            while (true)
            {
                var condexec = condition();
                lastValue = null;
                foreach(object o in condexec)
                {
                    lastValue = o;
                    yield return o;
                }
                if (lastValue is bool == false)
                    throw new OperationException(loopedReader, "Invalid returned value by condition");
                bool doLoop = (bool) lastValue;
                if (!doLoop)
                    break;
                DefaultLanguageNodes.Statement.Execute(loopedReader, loopScope, skipExec);
                loopedReader.Reset();
            }
        }
    }
}
