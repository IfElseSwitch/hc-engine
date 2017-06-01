using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Class for call operations
    /// </summary>
    public class Call : ISyntaxTreeItem
    {
        /// <summary>
        /// <see cref="ISyntaxTreeItem.Execute(ISourceReader, IExecutionScope)"/> 
        /// </summary>
        public IScriptExecution Execute(ISourceReader reader, IExecutionScope scope)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="ISyntaxTreeItem.IsStartOfNode(string)"/>
        /// </summary>
        public bool IsStartOfNode(string word)
        {
            throw new NotImplementedException();
        }

        //public override void Execute(ISourceReader reader, IExecutionScope scope)
        //{
        //    if (reader.ReadingComplete)
        //        throw new SyntaxException(reader, "Unexpected end of file");
        //    string word = reader.LastKeyword;
        //    m_Method = scope[word] as MethodInfo;
        //    if (m_Method == null)
        //        throw new SyntaxException(reader, string.Format("{0} is not a call", word));
        //    reader.ReadNext();
        //    m_Parameters = new List<AOperation>();
        //    foreach (var param in m_Method.GetParameters())
        //    {
        //        m_Parameters.Add(null);
        //    }
        //}


        //IEnumerator<object> Exec(IExecutionScope scope)
        //{
        //    object[] args = new object[m_Parameters.Count];
        //    ParameterInfo[] expected = m_Method.GetParameters();
        //    int i = 0;
        //    foreach (AOperation op in m_Parameters)
        //    {
        //        IScriptExecution exec = op.Execute(scope);
        //        object lastValue = null;
        //        foreach(object o in exec)
        //        {
        //            lastValue = o;
        //            yield return o;
        //        }
        //        if (!expected[i].ParameterType.IsAssignableFrom(lastValue.GetType()))
        //            throw new OperationException("", 0, 0, string.Format("Wrong parameter for argument {0} of call {1}", i, m_Method.Name));
        //        args[i++] = lastValue;
        //    }
        //    yield return m_Method.Invoke(null, args);
        //}
    }
}
