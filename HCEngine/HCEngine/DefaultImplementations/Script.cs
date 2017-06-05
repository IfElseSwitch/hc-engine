using System;
using System.Collections.Generic;
using HCEngine.DefaultImplementations.Language;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    ///     Default implementation of IScript
    /// </summary>
    public class Script : IScript
    {
        private readonly LoopedSourceReader m_Reader;
        private readonly IExecutionScope m_Scope;

        /// <summary>
        ///     Constructor for Script.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="defaultScope"></param>
        public Script(ISourceReader reader, IExecutionScope defaultScope)
        {
            m_Reader = new LoopedSourceReader(reader);
            m_Scope = defaultScope;
            var exec = DefaultLanguageNodes.ScriptRoot.Execute(m_Reader, m_Scope.MakeSubScope(), false);
            ExpectedArguments = exec.ExecuteNext() as IDictionary<string, Type>;
            m_Reader.Reset();
        }

        /// <summary>
        ///     <see cref="IScript.ExpectedArguments" />
        /// </summary>
        public IDictionary<string, Type> ExpectedArguments { get; }

        /// <summary>
        ///     <see cref="IScript.Run(IDictionary{string, object})" />
        /// </summary>
        public IScriptExecution Run(IDictionary<string, object> arguments)
        {
            m_Reader.Reset();
            var subscope = m_Scope.MakeSubScope();
            if (arguments != null)
                foreach (var kvp in arguments)
                    subscope[kvp.Key] = kvp.Value;
            var exec = DefaultLanguageNodes.ScriptRoot.Execute(m_Reader, subscope, false);
            exec.ExecuteNext(); // Skip the parameters map read (done in constructor)
            return exec;
        }
    }
}