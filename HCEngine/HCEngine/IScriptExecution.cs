using System.Collections.Generic;

namespace HCEngine
{
    /// <summary>
    /// Interface for managing a script's execution. 
    /// The execution cn be controlled by calling <see cref="IScriptExecution.ExecuteNext"/>, or by iterating though it with foreach as any <see cref="IEnumerable{T}"/>
    /// </summary>
    public interface IScriptExecution : IEnumerable<object>
    {
        /// <summary>
        /// Checks if the script still has operations to execute or if it is over.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// Execute the script up to the next operation. Will return the operation's intenal implementation's return object.
        /// </summary>
        /// <returns>The last operation's returned object. May be null.</returns>
        object ExecuteNext();
    }
}