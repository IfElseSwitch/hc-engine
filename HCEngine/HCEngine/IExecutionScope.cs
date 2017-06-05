using System.Collections.Generic;

namespace HCEngine
{
    /// <summary>
    ///     Interface for Execution Scopes
    /// </summary>
    public interface IExecutionScope
    {
        /// <summary>
        ///     Accesses a value by name
        /// </summary>
        /// <param name="identifier">name of the value</param>
        /// <returns>The value</returns>
        object this[string identifier] { get; set; }

        /// <summary>
        ///     All known identifiers.
        /// </summary>
        ICollection<string> KnownIdentifiers { get; }

        /// <summary>
        ///     Creates a scope which can access this scope and possess its own data.
        /// </summary>
        /// <returns>The new subscope</returns>
        IExecutionScope MakeSubScope();

        /// <summary>
        ///     Checks if the given name is known.
        /// </summary>
        /// <param name="identifier">Name to check for</param>
        /// <returns>True if the name exists in this scope, false otherwise</returns>
        bool Contains(string identifier);

        /// <summary>
        ///     Checks if a value is of a given type.
        /// </summary>
        /// <typeparam name="T">Type expected</typeparam>
        /// <param name="identifier">Name of the value to check</param>
        /// <returns>True if the value exists and is of the expected type, false otherwise</returns>
        bool IsOfType<T>(string identifier);
    }
}