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
        /// <see cref="ISyntaxTreeItem.ChildrenNodes"/> 
        /// </summary>
        public List<ISyntaxTreeItem> ChildrenNodes { get; set; } = new List<ISyntaxTreeItem>();

        /// <summary>
        /// <see cref="IInput.ParametersMap"/> 
        /// </summary>
        public IDictionary<string, Type> ParametersMap { get { return m_Parameters; } }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/>
        /// </summary>
        public abstract IScriptExecution Execute(IExecutionScope scope);

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public abstract void Setup(ISourceReader reader, IExecutionScope scope);
    }
}
