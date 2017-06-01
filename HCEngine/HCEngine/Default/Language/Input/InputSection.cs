using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing an Input section.
    /// </summary>
    public class InputSection : ISyntaxTreeItem
    {
        public List<ISyntaxTreeItem> ChildrenNodes
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IScriptExecution Execute(IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        public void Setup(ISourceReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
