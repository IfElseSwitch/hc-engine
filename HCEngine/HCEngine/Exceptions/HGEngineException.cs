using System;

namespace HCEngine
{
    /// <summary>
    /// Base class for exceptions thrown when interpreting a script.
    /// </summary>
    [Serializable]
    public abstract class HGEngineException : Exception
    {
        /// <summary>
        /// Constructor for HG Engine exceptions.
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="lineOfCode">Line of code where the error occurs</param>
        /// <param name="line">Line number at which the error occcurs</param>
        /// <param name="column">Column at which the error occurs</param>
        /// <param name="description">Description of the error</param>
        public HGEngineException(string errorType, string lineOfCode, int line, int column, string description)
        {
            ErrorType = errorType;
            LineOfCode = lineOfCode;
            Line = line;
            Column = column;
            Description = description;
        }

        /// <summary>
        /// Constructor for HG Engine exceptions, using a <see cref="ISourceReader"/> for line and column 
        /// </summary>
        /// <param name="errorType">Type of error as displayed to the user</param>
        /// <param name="reader"><see cref="ISourceReader"/> used to read the source</param>
        /// <param name="description">Description of the error</param>
        public HGEngineException(string errorType, ISourceReader reader, string description)
                    : this(errorType, reader.LineOfCode, reader.Line, reader.Column, description) { }

        /// <summary>
        /// <see cref="Exception.Message"/>
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("HG Engine {0} error in {1} at {2}:{3} : {4}",
                    ErrorType, LineOfCode, Line, Column, Description);
            }
        }
        
        /// <summary>
        /// The Line of code where the error is thrown
        /// </summary>
        public string LineOfCode { get; set; }

        /// <summary>
        /// Line number of the file at which the error is thrown.
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Column of the line at whch the error is thrown.
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Type of error as displayed to the user.
        /// </summary>
        public string ErrorType { get; set; }

        /// <summary>
        /// Description of the error
        /// </summary>
        public string Description { get; set; }
    }
}