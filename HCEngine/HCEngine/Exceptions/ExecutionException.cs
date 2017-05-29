namespace HCEngine
{
    /// <summary>
    /// Base class for Execution errors.
    /// Thrown when an error occurs during execution of the syntax tree.
    /// </summary>
    public abstract class ExecutionException : HGEngineException
    {

        /// <summary>
        /// Constructor for execution exceptions.
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="sourceFile">Path to the file where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public ExecutionException(string errorType, string sourceFile, int line, int column, string description)
            : base (errorType, sourceFile, line, column, description) { }

        /// <summary>
        /// Constructor for execution exceptions, using a <see cref="ISourceReader"/> for line and column.
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="sourceFile">Path to the file where the error occurs</param>
        /// <param name="reader"><see cref="ISourceReader"/> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public ExecutionException(string errorType, string sourceFile, ISourceReader reader, string description)
            : base (errorType, sourceFile, reader, description) { }
    }
}