using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public abstract class AStatement : ISyntaxTreeItem
    {
        public abstract List<ISyntaxTreeItem> ChildrenNodes { get; set; }

        public abstract IScriptExecution Execute(IExecutionScope scope);

        public abstract void Setup(ISourceReader reader, IExecutionScope scope);
    }
}
