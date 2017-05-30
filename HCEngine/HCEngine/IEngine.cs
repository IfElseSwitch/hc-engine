namespace HCEngine
{
    /// <summary>
    /// Interface for the entry point of the HC Engine.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Structure of the script language to interpret
        /// </summary>
        IScriptStructureDefinition Structure { get; set; }

        /// <summary>
        /// Reads a script source and builds the corresponding <see cref="IScript"/> object;
        /// </summary>
        /// <param name="source">Text of the script</param>
        /// <returns>The corresponding <see cref="IScript"/></returns>
        IScript LoadScript(string source);
    }
}
