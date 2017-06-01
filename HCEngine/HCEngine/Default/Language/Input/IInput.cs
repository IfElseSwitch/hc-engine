using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    /// <summary>
    /// Interface for the input section items
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// The expected parameters map declared. Binds a variable name to a Type.
        /// </summary>
        IDictionary<string, Type> ParametersMap { get; }
    }
}
