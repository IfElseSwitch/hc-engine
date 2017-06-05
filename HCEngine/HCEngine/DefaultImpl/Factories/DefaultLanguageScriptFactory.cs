using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    /// Language Structure definition for the default language.
    /// </summary>
    public class DefaultLanguageScriptFactory : IScriptFactory
    {
        /// <summary>
        /// <see cref="IScriptFactory.CreateScript(ISourceReader, IExecutionScope)"/>
        /// </summary>
        public IScript CreateScript(ISourceReader reader, IExecutionScope scope)
        {
            return new Script(reader, scope);
        }
    }
}
