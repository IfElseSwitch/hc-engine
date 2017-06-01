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

        public abstract List<ISyntaxTreeItem> ChildrenNodes { get; set; }

        public IDictionary<string, Type> ParametersMap { get { return m_Parameters; } }

        public abstract IScriptExecution Execute(IExecutionScope scope);

        public abstract void Setup(ISourceReader reader, IExecutionScope scope);
    }
}
