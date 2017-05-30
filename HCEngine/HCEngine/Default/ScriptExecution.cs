using System.Collections;
using System.Collections.Generic;

namespace HCEngine.Default
{
    /// <summary>
    /// Default implementation of IScriptExecution.
    /// Uses a coroutine to bind the logic.
    /// </summary>
    public class ScriptExecution : IScriptExecution
    {
        /// <summary>
        /// Underlying coroutine for the execution
        /// </summary>
        IEnumerator<object> m_Execution;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execution">Underlying coroutine</param>
        public ScriptExecution(IEnumerator<object> execution)
        {
            m_Execution = execution;
            IsAlive = true;
        }

        /// <summary>
        /// <see cref="IScriptExecution.IsAlive"/>
        /// </summary>
        public bool IsAlive
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="IScriptExecution.ExecuteNext"/> 
        /// </summary>
        public object ExecuteNext()
        {
            if (m_Execution == null)
                return null;
            if (m_Execution.MoveNext())
                return m_Execution.Current;
            IsAlive = false;
            return true;
        }

        /// <summary>
        /// <see cref="IEnumerable{T}.GetEnumerator"/> 
        /// </summary>
        public IEnumerator<object> GetEnumerator()
        {
            return m_Execution;
        }

        /// <summary>
        /// <see cref="IEnumerable.GetEnumerator"/>
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_Execution;
        }
    }
}
