using System;

namespace HCEngine
{
    /// <summary>
    ///     Exception for Scope errors.
    ///     Thrown when trying to access a non-existant container
    /// </summary>
    [Serializable]
    public class ScopeException : ExecutionException
    {
        private const string c_ErrorType = "Scope";

        /// <summary>
        ///     Constructor for scope exceptions.
        /// </summary>
        /// <param name="lineOfCode">Line of code where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public ScopeException(string lineOfCode, int line, int column, string description)
            : base(c_ErrorType, lineOfCode, line, column, description)
        {
        }

        /// <summary>
        ///     Constructor for scope exceptions, using a <see cref="ISourceReader" /> for line and column.
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader" /> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public ScopeException(ISourceReader reader, string description)
            : base(c_ErrorType, reader, description)
        {
        }
    }
}