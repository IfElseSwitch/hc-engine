using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public class Constant : ISyntaxTreeItem
    {
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        public bool IsStartOfNode(string word)
        {
            throw new NotImplementedException();
        }
    }
}
