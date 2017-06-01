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
        public abstract List<ISyntaxTreeItem> ChildrenNodes { get; set; }

        public abstract IDictionary<string, Type> ParametersMap { get; }

        public abstract IScriptExecution Execute(IExecutionScope scope);

        public abstract void Setup(ISourceReader reader);
    }
}
