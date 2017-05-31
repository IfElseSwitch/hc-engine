using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine
{
    /// <summary>
    /// Attribute marking a public type as visible from user scripts.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExposedTypeAttribute : Attribute
    {
        /// <summary>
        /// Set if the name of the type should be different in scripts
        /// </summary>
        public string NameOverride { get; set; }

        /// <summary>
        /// Set if another type should be used in place of the tagged type
        /// </summary>
        public Type LinkToType { get; set; }

        /// <summary>
        /// Default constructor. ExposedType has no position parameters.
        /// </summary>
        public ExposedTypeAttribute() { }
    }
}
