using System;

namespace HCEngine
{
    /// <summary>
    /// Base class for Execution errors.
    /// Thrown when an error occurs during execution of the syntax tree.
    /// </summary>
    [Serializable]
    public abstract class ExecutionException : HCEngineException
    {

        /// <summary>
        /// Constructor for execution exceptions.
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="lineOfCode">Line of code where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        protected ExecutionException(string errorType, string lineOfCode, int line, int column, string description)
            : base (errorType, lineOfCode, line, column, description) { }

        /// <summary>
        /// Constructor for execution exceptions, using a <see cref="ISourceReader"/> for line and column.
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="reader"><see cref="ISourceReader"/> used to read the source</param>
        /// <param name="description">Description of the error</param>
        protected ExecutionException(string errorType, ISourceReader reader, string description)
            : base (errorType, reader, description) { }
    }
}