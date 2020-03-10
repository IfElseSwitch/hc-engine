using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    ///     Default implementation of <see cref="IExecutionScope" />.
    /// </summary>
    public class ExecutionScope : IExecutionScope
    {
        private readonly IExecutionScope m_Parent;
        private readonly IDictionary<string, object> m_Values;

        /// <summary>
        ///     Constructor for creating a subscope of a parent scope.
        /// </summary>
        /// <param name="parent">Origin of the subscope</param>
        public ExecutionScope(IExecutionScope parent)
        {
            m_Parent = parent;
            m_Values = new Dictionary<string, object>();
        }

        /// <summary>
        ///     Constructor for creating a default scope.
        /// </summary>
        public ExecutionScope() : this(null)
        {
        }

        /// <summary>
        ///     <see cref="IExecutionScope.KnownIdentifiers" />
        /// </summary>
        public ICollection<string> KnownIdentifiers
        {
            get
            {
                var keys = new List<string>();
                keys.AddRange(m_Values.Keys);
                if (m_Parent != null)
                    keys.AddRange(m_Parent.KnownIdentifiers);
                return keys;
            }
        }

        /// <summary>
        ///     <see cref="IExecutionScope.this[string]" />
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1065:DoNotRaiseExceptionsInUnexpectedLocations")]
        public object this[string identifier]
        {
            get
            {
                if (m_Values.ContainsKey(identifier))
                    return m_Values[identifier];
                if (m_Parent != null)
                    return m_Parent[identifier];
                throw new ScopeException("", 0, 0,
                    string.Format("identifier {0} unknown in current scope", identifier));
            }

            set
            {
                if (m_Parent != null && m_Parent.Contains(identifier))
                {
                    m_Parent[identifier] = value;
                    return;
                }
                if (!m_Values.ContainsKey(identifier))
                    m_Values.Add(identifier, null);
                m_Values[identifier] = value;
            }
        }

        /// <summary>
        ///     <see cref="IExecutionScope.Contains(string)" />
        /// </summary>
        public bool Contains(string identifier)
        {
            return m_Values.ContainsKey(identifier) || m_Parent != null && m_Parent.Contains(identifier);
        }

        /// <summary>
        ///     <see cref="IExecutionScope.IsOfType{T}(string)" />
        /// </summary>
        public bool IsOfType<T>(string identifier)
        {
            if (!Contains(identifier))
                return false;
            return this[identifier] is T;
        }

        /// <summary>
        ///     <see cref="IExecutionScope.MakeSubScope" />
        /// </summary>
        public IExecutionScope MakeSubScope()
        {
            return new ExecutionScope(this);
        }

        /// <summary>
        ///     <see cref="IExecutionScope.IsGeneric" />
        /// </summary>
        public bool IsGeneric(string identifier)
        {
            string genTestIdentifier = string.Format("gen:{0}", identifier);
            return Contains(genTestIdentifier);
        }
    }
}