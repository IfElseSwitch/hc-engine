using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.DefaultImplementations
{
    /// <summary>
    /// Source reader which buffers the result of another source reader when needed and can loop over the buffer.
    /// </summary>
    public class LoopedSourceReader : ISourceReader
    {
        class Snapshot
        {
            public Snapshot(ISourceReader toSnap)
            {
                LastKeyword = toSnap.LastKeyword;
                Column = toSnap.Column;
                Line = toSnap.Line;
                LineOfCode = toSnap.LineOfCode;
                ReadingComplete = toSnap.ReadingComplete;
            }

            public string LastKeyword { get; private set; }

            public int Column { get; private set; }

            public int Line { get; private set; }

            public string LineOfCode { get; private set; }

            public bool ReadingComplete { get; private set; }

        }

        ISourceReader m_Parent;
        List<Snapshot> m_Read;
        int m_Current;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">The source reader to buffer. The current keyword will be the first of the loop.</param>
        public LoopedSourceReader(ISourceReader parent)
        {
            m_Parent = parent;
            m_Read = new List<Snapshot>();
            m_Current = 0;
            AddSnapshot();
        }

        /// <summary>
        /// <see cref="ISourceReader.Column"/> 
        /// </summary>
        public int Column
        {
            get
            {
                return m_Read[m_Current].Column;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.LastKeyword"/>
        /// </summary>
        public string LastKeyword
        {
            get
            {
                return m_Read[m_Current].LastKeyword;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.Line"/>
        /// </summary>
        public int Line
        {
            get
            {
                return m_Read[m_Current].Line;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.LineOfCode"/>
        /// </summary>
        public string LineOfCode
        {
            get
            {
                return m_Read[m_Current].LineOfCode;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.ReadingComplete"/>
        /// </summary>
        public bool ReadingComplete
        {
            get
            {
                return m_Read[m_Current].ReadingComplete;
            }
        }

        /// <summary>
        /// <see cref="ISourceReader.Initialize(string)"/>
        /// </summary>
        public void Initialize(string source)
        {
            m_Parent.Initialize(source);
            m_Read = new List<Snapshot>();
            AddSnapshot();
        }

        /// <summary>
        /// <see cref="ISourceReader.ReadNext"/>
        /// </summary>
        public void ReadNext()
        {
            ++m_Current;
            if (m_Current >= m_Read.Count)
            {
                m_Parent.ReadNext();
                AddSnapshot();
            }
        }

        /// <summary>
        /// Resets the reader to its position when instantiated.
        /// </summary>
        public void Reset()
        {
            m_Current = 0;
        }

        /// <summary>
        /// Removes the first snapshot (useful to prepare a looped reader before the reader is at the correct position)
        /// </summary>
        public void ForgetFirst()
        {
            m_Read.RemoveAt(0);
        }

        /// <summary>
        /// Adds a snapshot without moving the current index. Useful when the looped reader was prepared before the reader was at the correct position.
        /// </summary>
        public void AddSnapshot()
        {
            m_Read.Add(new Snapshot(m_Parent));
        }
    }
}
