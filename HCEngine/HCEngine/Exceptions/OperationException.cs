using System;

namespace HCEngine
{
    /// <summary>
    ///     Exception for Operation errors.
    ///     Thrown when a call receives wrong arguments
    /// </summary>
    [Serializable]
    public class OperationException : ExecutionException
    {
        private const string c_ErrorType = "Operation";

        /// <summary>
        ///     Constructor for operation exceptions.
        /// </summary>
        /// <param name="lineOfCode">Line of code where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public OperationException(string lineOfCode, int line, int column, string description)
            : base(c_ErrorType, lineOfCode, line, column, description)
        {
        }

        /// <summary>
        ///     Constructor for operation exceptions, using a <see cref="ISourceReader" /> for line and column.
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader" /> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public OperationException(ISourceReader reader, string description)
            : base(c_ErrorType, reader, description)
        {
        }
    }
}