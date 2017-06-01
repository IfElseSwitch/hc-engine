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
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        /// <remarks>As for all items in the input section, will do nothing and return null.</remarks>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            return null;
        }
        
        //public void Setup(ISourceReader reader, IExecutionScope scope)
        //{
        //    if (reader.ReadingComplete)
        //        throw new SyntaxException(reader, "Unexpected end of file");
        //    if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.InputKeyword))
        //        throw new SyntaxException(reader, "Input sections should start with the input keyword");
        //    reader.ReadNext();
        //    if (reader.ReadingComplete)
        //        throw new SyntaxException(reader, "Unexpected end of file");
        //    AInputStatement statement = null;
        //    if (reader.LastKeyword.Equals(DefaultLanguageKeywords.ListBeginSymbol))
        //        statement = new DeclarationList();
        //    else
        //        statement = new InputDeclaration();
        //    statement.Setup(reader, scope);
        //    ChildrenNodes.Add(statement);
        //    foreach (var kvp in statement.ParametersMap)
        //        ParametersMap.Add(kvp);
        //}
    }
}
