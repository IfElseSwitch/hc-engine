namespace HCEngine
{
    /// <summary>
    ///     Interface for default scope factories.
    /// </summary>
    public interface IScopeFactory
    {
        /// <summary>
        ///     Creates a scope initialized with default values.
        /// </summary>
        /// <returns>An initialized default scope.</returns>
        IExecutionScope MakeScope();
    }
}