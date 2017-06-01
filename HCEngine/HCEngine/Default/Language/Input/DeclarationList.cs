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
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(IExecutionScope)"/>
        /// </summary>
        /// <remarks>As for all items in the input section, will do nothing and return null.</remarks>
        public override IScriptExecution Execute(IExecutionScope scope)
        {
            return null;
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public override void Setup(ISourceReader reader, IExecutionScope scope)
        {
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.ListBeginSymbol))
                throw new SyntaxException(reader, "Lists should start with the list begin symbol.");
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            while (!reader.LastKeyword.Equals(DefaultLanguageKeywords.ListEndSymbol))
            {
                InputDeclaration declaration = new InputDeclaration();
                declaration.Setup(reader, scope);
                if (reader.ReadingComplete)
                    throw new SyntaxException(reader, "Unexpected end of file");
                ChildrenNodes.Add(declaration);
                foreach (var kvp in declaration.ParametersMap)
                    ParametersMap.Add(kvp);
            }
            reader.ReadNext();
        }
    }
}
