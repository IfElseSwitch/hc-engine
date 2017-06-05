using System;

namespace HCEngine
{
    /// <summary>
    ///     Attribute marking a publc static method as accessible from scripts.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ExposedCallAttribute : Attribute
    {
        /// <summary>
        ///     Set if the name of the call should be different in scripts
        /// </summary>
        public string NameOverride { get; set; }
    }
}