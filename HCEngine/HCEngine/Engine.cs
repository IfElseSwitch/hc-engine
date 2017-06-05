using HCEngine.DefaultImplementations;
using System.Collections.Generic;

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
            if (factory == null)
                factory = new ScopeFactory();
            ReaderFactory = new SourceReaderFactory();
            ScriptFactory = new DefaultLanguageScriptFactory();
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
        /// Factory of the script language to interpret.
        /// </summary>
        public IScriptFactory ScriptFactory
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
        public IScript LoadScript(string source)
        {
            return ScriptFactory.CreateScript(ReaderFactory.MakeReader(source), DefaultScope);
        }

        /// <summary>
        /// Loads a script, and execute it completely with the given arguments.
        /// </summary>
        /// <param name="source">Script source code</param>
        /// <param name="arguments">Arguments to give to the script</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1804:RemoveUnusedLocals", MessageId = "o")]
        public void LoadAndRun(string source, IDictionary<string, object> arguments)
        {
            IScript script = LoadScript(source);
            var exec = script.Run(arguments);
            foreach (object o in exec)
                ;
        }

        /// <summary>
        /// Loads a script, and execute it completely with no arguments.
        /// </summary>
        /// <param name="source">Script source code</param>
        public void LoadAndRun(string source)
        {
            LoadAndRun(source, new Dictionary<string, object>());
        }
    }
}
