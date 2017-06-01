using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Base class representing input statements
    /// </summary>
    public abstract class AInputStatement : ISyntaxTreeItem, IInput
    {
        private IDictionary<string, Type> m_Parameters = new Dictionary<string, Type>();
        
        /// <summary>
        /// <see cref="IInput.ParametersMap"/> 
        /// </summary>
        public IDictionary<string, Type> ParametersMap { get { return m_Parameters; } }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public abstract IScriptExecution Execute(ISourceReader reader, IExecutionScope scope);
        
    }
}
