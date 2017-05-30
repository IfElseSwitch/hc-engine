namespace HCEngine
{
    public interface IScriptStructureDefinition
    {
        /// <summary>
        /// Builds the syntax tree from an initialized <see cref="ISourceReader" />.
        /// </summary>
        /// <param name="reader">Initialized reader to use for building the syntax tree.</param>
        ISyntaxTreeItem CreateSyntaxTree(ISourceReader reader);
    }
}