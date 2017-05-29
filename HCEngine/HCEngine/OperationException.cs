namespace HCEngine
{
    /// <summary>
    /// Exception for Operation errors.
    /// Thrown when a call receives wrong arguments
    /// </summary>
    public class OperationException : ExecutionException
    {
        private const string c_ErrorType = "Operation";

        /// <summary>
        /// Constructor for operation exceptions.
        /// </summary>
        /// <param name="sourceFile">Path to the file where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public OperationException(string sourceFile, int line, int column, string description)
            : base(c_ErrorType, sourceFile, line, column, description) { }

        /// <summary>
        /// Constructor for operation exceptions, using a <see cref="ISourceReader"/> for line and column.
        /// </summary>
        /// <param name="sourceFile">Path to the file where the error occurs</param>
        /// <param name="reader"><see cref="ISourceReader"/> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public OperationException(string sourceFile, ISourceReader reader, string description)
            : base(c_ErrorType, sourceFile, reader, description) { }
    }
}