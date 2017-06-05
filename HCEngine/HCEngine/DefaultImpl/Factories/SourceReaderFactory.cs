using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    /// Factory for the default source reader
    /// </summary>
    public class SourceReaderFactory : ISourceReaderFactory
    {
        /// <summary>
        /// <see cref="ISourceReaderFactory.MakeReader(string)"/>
        /// </summary>
        public ISourceReader MakeReader(string source)
        {
            SourceReader reader = new SourceReader();
            reader.Initialize(source);
            return reader;
        }
    }
}
