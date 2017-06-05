using System;
using System.Collections.Generic;

namespace HCEngine
{
    /// <summary>
    ///     Interface for loaded scripts
    /// </summary>
    public interface IScript
    {
        /// <summary>
        ///     Expected arguments types for the script, keyed by identifiers
        /// </summary>
        IDictionary<string, Type> ExpectedArguments { get; }

        /// <summary>
        ///     Creates a <see cref="IScriptExecution" /> for this script with the given arguments
        /// </summary>
        /// <param name="arguments">The arguments to give to the script execution, as a map from identifier to instance</param>
        /// <returns>The execution object</returns>
        IScriptExecution Run(IDictionary<string, object> arguments);
    }
}