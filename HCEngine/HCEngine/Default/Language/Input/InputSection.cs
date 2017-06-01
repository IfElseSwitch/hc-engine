using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing an Input section.
    /// </summary>
    public class InputSection : ISyntaxTreeItem, IInput
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.ChildrenNodes"/>
        /// </summary>
        public List<ISyntaxTreeItem> ChildrenNodes { get; set; } = new List<ISyntaxTreeItem>();

        /// <summary>
        /// <see cref="IInput.ParametersMap"/>
        /// </summary>
        public IDictionary<string, Type> ParametersMap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/>
        /// </summary>
        /// <remarks>As for all items in the input section, will do nothing and return null.</remarks>
        public IScriptExecution Execute(IExecutionScope scope)
        {
            return null;
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="scope"></param>
        public void Setup(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }
    }
}
