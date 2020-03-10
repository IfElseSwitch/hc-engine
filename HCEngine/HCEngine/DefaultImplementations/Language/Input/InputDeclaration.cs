using System;
using System.Collections.Generic;

namespace HCEngine.DefaultImplementations.Language
{
    /// <summary>
    ///     Class representing a single Input declaration.
    /// </summary>
    public class InputDeclaration : ISyntaxTreeItem
    {
        /// <summary>
        ///     <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope, bool)" />
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope, bool skipExec)
        {
            return new ScriptExecution(Exec(reader, scope));
        }

        /// <summary>
        ///     <see cref="ISyntaxTreeItem.IsStartOfNode(string, IExecutionScope)" />
        /// </summary>
        public bool IsStartOfNode(string word, IExecutionScope scope)
        {
            return DefaultLanguageNodes.Variable.IsStartOfNode(word, scope);
        }

        private IEnumerator<object> Exec(ISourceReader reader, IExecutionScope scope)
        {
            var exec = DefaultLanguageNodes.Variable.Execute(reader, scope, true);
            IDictionary<string, Type> parametersMap = new Dictionary<string, Type>();
            var id = exec.ExecuteNext() as string;
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.TypingKeyword))
                throw new SyntaxException(reader,
                    "In a declaration, the Typing keyword should follow the variable name.");
            Type t = ReadType(reader, scope);
            parametersMap.Add(id, t);
            reader.ReadNext();
            yield return parametersMap;
        }

        private static Type ReadType(ISourceReader reader, IExecutionScope scope)
        {
            reader.ReadNext();
            if (reader.ReadingComplete)
                throw new SyntaxException(reader, "Unexpected end of file");
            if (!scope.Contains(reader.LastKeyword) || !scope.IsOfType<Type>(reader.LastKeyword))
                throw new SyntaxException(reader, string.Format("Unknown type {0}", reader.LastKeyword));
            var t = scope[reader.LastKeyword] as Type;
            if (t == null)
                throw new SyntaxException(reader, "Type resolving failed.");
            if (scope.IsGeneric(reader.LastKeyword))
            {
                reader.ReadNext();
                if (!reader.LastKeyword.Equals(DefaultLanguageKeywords.GenericTypeArgumentKeyword))
                {
                    throw new SyntaxException(reader,
                        "In a Generic declaration, the Generic argument keyword should follow the Type name.");
                }
                Type innerType = ReadType(reader, scope);
                t = t.GetGenericTypeDefinition().MakeGenericType(innerType);
            }

            return t;
        }
    }
}