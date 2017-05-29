namespace HCEngine
{
    /// <summary>
    /// Interface for reading a source code keyword by keyword.
    /// </summary>
    public interface ISourceReader
    {
        /// <summary>
        /// Initializes the reader to a new source. 
        /// This method serves to avoid intanciating multiple times the reader.
        /// </summary>
        /// <param name="source">Source to read</param>
        void Initialize(string source);

        /// <summary>
        /// Last keyword read. null when the source is completely read
        /// </summary>
        string LastKeyword { get; }

        /// <summary>
        /// Reads the next keyword, which becomes the <see cref="LastKeyword"/>
        /// </summary>
        void ReadNext();

        /// <summary>
        /// Is the source code completely read?
        /// </summary>
        bool ReadingComplete { get; }

        /// <summary>
        /// Line of the last keyword read
        /// </summary>
        int Line { get; }

        /// <summary>
        /// Column of the last keyword read
        /// </summary>
        int Column { get; }
    }
}
