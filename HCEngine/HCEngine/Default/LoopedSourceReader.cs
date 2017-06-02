using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default
{
    public class LoopedSourceReader : ISourceReader
    {
        ISourceReader m_Parent;
        List<string> m_Read;
        int m_Current;

        public LoopedSourceReader(ISourceReader parent)
        {
            m_Parent = parent;
            m_Read = new List<string>();
            m_Current = 0;
            m_Read.Add(parent.LastKeyword);
        }

        public int Column
        {
            get
            {
                return m_Parent.Column;
            }
        }

        public string LastKeyword
        {
            get
            {
                if (m_Current >= 0)
                    return m_Read[m_Current];
                return null;
            }
        }

        public int Line
        {
            get
            {
                return m_Parent.Line;
            }
        }

        public string LineOfCode
        {
            get
            {
                return m_Parent.LineOfCode;
            }
        }

        public bool ReadingComplete
        {
            get
            {
                return m_Parent.ReadingComplete;
            }
        }

        public void Initialize(string source)
        {
            m_Parent.Initialize(source);
        }

        public void ReadNext()
        {
            ++m_Current;
            if (m_Current >= m_Read.Count)
            {
                m_Parent.ReadNext();
                m_Read.Add(m_Parent.LastKeyword);
            }
        }

        public void Reset()
        {
            m_Current = 0;
        }
    }
}
