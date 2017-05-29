using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HCEngine.Default
{
    /// <summary>
    /// Reads though a source code.
    /// Underlying implementation uses a yielded method to actually read.
    /// </summary>
    public class SourceReader : ISourceReader
    {
        /// <summary>
        /// Lazy reader
        /// </summary>
        IEnumerator<string> m_Reader;

        /// <summary>
        /// <see cref="ISourceReader.LastKeyword"/>
        /// </summary>
        public string LastKeyword
        {
            get
            {
                if (m_Reader == null)
                    return null;
                return m_Reader.Current;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.ReadingComplete"/>
        /// </summary>
        public bool ReadingComplete
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="ISourceReader.Line"/>
        /// </summary>
        public int Line
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="ISourceReader.Column"/>
        /// </summary>
        public int Column
        {
            get;
            private set;
        }

        /// <summary>
        /// <see cref="ISourceReader.Initialize(string)"/>
        /// </summary>
        public void Initialize(string source)
        {
            m_Reader = Read(source);
            ReadingComplete = false;
            ReadNext();
        }

        /// <summary>
        /// <see cref="ISourceReader.ReadNext"/>
        /// </summary>
        public void ReadNext()
        {
            if (m_Reader == null)
                return;
            if (!m_Reader.MoveNext())
            {
                ReadingComplete = true;
                m_Reader = null;
            }
        }

        /// <summary>
        /// The yielded method to lazily read the source.
        /// Iterates on each character of the source, and adds them to a buffer. 
        /// When a whitespace is encountered (and not reading a string), the buffer's content is retreived, the buffer is cleared, and the content yielded.
        /// </summary>
        /// <param name="source">The source code to read</param>
        /// <returns></returns>
        IEnumerator<string> Read(string source)
        {
            StringBuilder nextWord = new StringBuilder();
            bool isReadingString = false;
            Line = 0;
            Column = 1;
            using (StringReader sr = new StringReader(source))
            {
                string line;
                while (null != ( line = sr.ReadLine() ))
                {
                    ++Line;
                    Column = 1;
                    int col = 0;
                    foreach (char c in line)
                    {
                        ++col;
                        if (c == '"')
                        {
                            isReadingString = !isReadingString;
                        }
                        if (char.IsWhiteSpace(c) && !isReadingString)
                        {
                            if (nextWord.Length > 0)
                            {
                                string keyword = nextWord.ToString();
                                nextWord.Clear();
                                yield return keyword;
                            }
                            Column = col + 1;
                        }
                        else
                        {
                            nextWord.Append(c);
                        }
                    }
                    if (nextWord.Length > 0)
                        yield return nextWord.ToString();
                }
            }
            
        }
    }
}
