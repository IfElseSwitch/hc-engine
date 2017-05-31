namespace HCEngine
{
    /// <summary>
    /// Class for Syntax errors.
    /// Thrown when an error occurs during building of the syntax tree. 
    /// </summary>
    public class SyntaxException : HGEngineException
    {
        const string c_ErrorType = "Syntax";

        /// <summary>
        /// Constructor for syntax exceptions.
        /// </summary>
        /// <param name="lineOfCode">Line of code where the error occurs</param>
        /// <param name="line">Line at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public SyntaxException(string lineOfCode, int line, int column, string description)
            : base(c_ErrorType, lineOfCode, line, column, description) { }

        /// <summary>
        /// Constructor for syntax exceptions, using a <see cref="ISourceReader"/> for line and column.
        /// </summary>
        /// <param name="reader"><see cref="ISourceReader"/> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public SyntaxException(ISourceReader reader, string description)
            : base(c_ErrorType, reader, description) { }
    }
}