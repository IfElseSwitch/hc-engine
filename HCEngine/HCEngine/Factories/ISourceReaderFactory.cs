using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine
{
    /// <summary>
    /// Factory interface for making <see cref="ISourceReader"/>s.
    /// </summary>
    public interface ISourceReaderFactory
    {
        /// <summary>
        /// Returns a <see cref="ISourceReader"/> bound to the source text. 
        /// </summary>
        /// <param name="source">Text to read</param>
        /// <returns>Initialized <see cref="ISourceReader"/></returns>
        ISourceReader MakeReader(string source);
    }
}
