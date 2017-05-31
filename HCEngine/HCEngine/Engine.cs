using HCEngine.Default;

namespace HCEngine
{
    /// <summary>
    /// Interface for the entry point of the HC Engine.
    /// </summary>
    public sealed class Engine
    {
        /// <summary>
        /// Constructor without using the default factory
        /// </summary>
        /// <param name="factory">Factory to build the default scope</param>
        public Engine(IScopeFactory factory)
        {
            Reader = new SourceReader();
            Structure = new DefaultLanguageStructure();
            DefaultScope = factory.MakeScope();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Engine()
            :this(new ScopeFactory())
        { }

        /// <summary>
        /// The <see cref="ISourceReader" /> used for reading sources.
        /// </summary>
        public ISourceReader Reader
        {
            get;
            set;
        }

        /// <summary>
        /// Structure of the script language to interpret.
        /// </summary>
        public IScriptStructureDefinition Structure
        {
            get;
            set;
        }

        /// <summary>
        /// The default scope for script executions.
        /// </summary>
        public IExecutionScope DefaultScope
        {
            get;
            private set;
        }

        /// <summary>
        /// Reads a script source and builds the corresponding <see cref="IScript"/> object;
        /// </summary>
        /// <param name="source">Text of the script</param>
        /// <returns>The corresponding <see cref="IScript"/></returns>
        IScript LoadScript(string source)
        {
            throw new System.NotImplementedException();
        }
    }
}
