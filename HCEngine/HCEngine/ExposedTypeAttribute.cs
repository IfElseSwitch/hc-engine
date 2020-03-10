using System;

namespace HCEngine
{
    /// <summary>
    ///     Interface to instanciate an exposed type from a word.
    /// </summary>
    public interface IConstantReader
    {
        /// <summary>
        ///     Tries to create an instance of the bound type from the string word.
        ///     Returns true if an instance is created.
        /// </summary>
        /// <param name="word">Word to use for instantiation</param>
        /// <param name="instance">Instance created</param>
        /// <returns>True if an instance is created, false otherwise.</returns>
        bool TryRead(string word, out object instance);
    }

    /// <summary>
    ///     Attribute marking a public type as visible from user scripts.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ExposedTypeAttribute : Attribute
    {
        /// <summary>
        ///     Set if the name of the type should be different in scripts.
        /// </summary>
        public string NameOverride { get; set; }

        /// <summary>
        ///     Set if another type should be used in place of the tagged type.
        /// </summary>
        public Type LinkToType { get; set; }

        /// <summary>
        ///     Type of the implementation of IConstantReader that reads constants for this type.
        /// </summary>
        public Type ConstantReaderType { get; set; }

        /// <summary>
        ///     Is the type generic ? 
        /// </summary>
        public bool Generic { get; set; } = false;

        /// <summary>
        ///     Helper method to resolve the ConstantReader for an exposed type attribute
        /// </summary>
        /// <param name="exposed"></param>
        /// <returns></returns>
        public static IConstantReader ResolveConstantReader(ExposedTypeAttribute exposed)
        {
            if (exposed == null)
                return null;
            if (exposed.ConstantReaderType == null)
                return null;
            var t = exposed.ConstantReaderType;
            if (!typeof(IConstantReader).IsAssignableFrom(t))
                throw new OperationException("", 0, 0,
                    string.Format("The ConstantReaderType {0} doesn't implement IConstantReader",
                        exposed.ConstantReaderType.Name));
            return Activator.CreateInstance(t) as IConstantReader;
        }
    }
}