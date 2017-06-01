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
        private IDictionary<string, Type> m_Parameters = new Dictionary<string, Type>();

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
                return m_Parameters;
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
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.InputKeyword))
                throw new SyntaxException(reader, "Input sections should start with the input keyword");
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            AInputStatement statement = null;
            if (reader.LastKeyword.Equals(DefaultLanguageKeywords.ListBeginSymbol))
                statement = new DeclarationList();
            else
                statement = new InputDeclaration();
            statement.Setup(reader, scope);
            ChildrenNodes.Add(statement);
            foreach (var kvp in statement.ParametersMap)
                ParametersMap.Add(kvp);
        }
    }
}
