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
            ReaderFactory = new SourceReaderFactory();
            Structure = new DefaultLanguageScriptFactory();
            DefaultScope = factory.MakeScope();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Engine()
            :this(new ScopeFactory())
        { }

        /// <summary>
        /// The <see cref="ISourceReaderFactory" /> used for reading sources.
        /// </summary>
        public ISourceReaderFactory ReaderFactory
        {
            get;
            set;
        }

        /// <summary>
        /// Structure of the script language to interpret.
        /// </summary>
        public IScriptFactory Structure
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
            return Structure.CreateScript(ReaderFactory.MakeReader(source), DefaultScope);
        }
    }
}
