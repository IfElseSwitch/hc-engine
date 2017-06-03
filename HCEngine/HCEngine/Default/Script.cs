using HCEngine.Default.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default
{
    /// <summary>
    /// Default implementation of IScript
    /// </summary>
    public class Script : IScript
    {
        LoopedSourceReader m_Reader;
        IExecutionScope m_Scope;

        /// <summary>
        /// Constructor for Script. 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="defaultScope"></param>
        public Script(ISourceReader reader, IExecutionScope defaultScope)
        {
            m_Reader = new LoopedSourceReader(reader);
            m_Scope = defaultScope.MakeSubScope();
            var exec = DefaultLanguageNodes.ScriptRoot.Execute(m_Reader, m_Scope, false);
            ExpectedArguments = exec.ExecuteNext() as IDictionary<string, Type>;
            m_Reader.Reset();
        }

        /// <summary>
        /// <see cref="IScript.ExpectedArguments"/>
        /// </summary>
        public IDictionary<string, Type> ExpectedArguments { get; private set; }

        /// <summary>
        /// <see cref="IScript.Run(IDictionary{string, object})"/> 
        /// </summary>
        public IScriptExecution Run(IDictionary<string, object> arguments)
        {
            var exec = DefaultLanguageNodes.ScriptRoot.Execute(m_Reader, m_Scope, false);
            exec.ExecuteNext(); // Skip the parameters map read (done in constructor)
            return exec;
        }
    }
}
