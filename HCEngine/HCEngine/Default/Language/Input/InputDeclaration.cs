using System;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class representing a single Input declaration.
    /// </summary>
    public class InputDeclaration : AInputStatement
    {
        ///// <summary>
        ///// <see cref="ISyntaxTreeItem.Setup(ISourceReader, IExecutionScope)"/> 
        ///// </summary>
        //public override void Setup(ISourceReader reader, IExecutionScope scope)
        //{
        //    Variable v = new Variable();
        //    v.Setup(reader, scope);
        //    if (reader.ReadingComplete)
        //        throw new SyntaxException(reader, "Unexpected end of file");
        //    if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.TypingKeyword))
        //        throw new SyntaxException(reader, "In a declaration, the Typing keyword should follow the variable name.");
        //    reader.ReadNext();
        //    if (reader.ReadingComplete)
        //        throw new SyntaxException(reader, "Unexpected end of file");
        //    if (!scope.Contains(reader.LastKeyword) || !scope.IsOfType<Type>(reader.LastKeyword))
        //        throw new SyntaxException(reader, string.Format("Unknown type {0}", reader.LastKeyword));
        //    Type t = scope[reader.LastKeyword] as Type;
        //    if (t == null)
        //        throw new SyntaxException(reader, "Type resolving failed.");
        //    ParametersMap.Add(v.Identifier, t);
        //    reader.ReadNext();
        //}

        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public override IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }
    }
}
