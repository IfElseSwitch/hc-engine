using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing a List of declarations.
    /// </summary>
    public class DeclarationList : AInputStatement
    {
        public override List<ISyntaxTreeItem> ChildrenNodes
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

        public override IDictionary<string, Type> ParametersMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override IScriptExecution Execute(IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        public override void Setup(ISourceReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
