namespace HCEngine
{
    /// <summary>
    /// Interface for the defition of the expected script structure.
    /// </summary>
    public interface IScriptFactory
    {
        /// <summary>
        /// Builds the script from an initialized <see cref="ISourceReader" /> and <see cref="IExecutionScope"/>.
        /// </summary>
        /// <param name="reader">Initialized reader to use for building the syntax tree.</param>
        /// <param name="scope">Initialized scope for the script execution</param>
        IScript CreateScript(ISourceReader reader, IExecutionScope scope);
    }
}