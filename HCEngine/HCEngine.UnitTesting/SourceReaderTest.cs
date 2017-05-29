using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;

namespace HCEngine.UnitTesting
{
    [TestClass]
    public class SourceReaderTest
    {
        [TestMethod]
        public void TestReadingNormal()
        {
            string[] expected = new string[] { "reading", "this", "should", "be", "ok" };
            string compact = "reading this should be ok";
            string padded = "    reading    this  should be ok  \n";
            ISourceReader reader = new SourceReader();
            reader.Initialize(compact);
            TestReader(reader, expected);
            reader.Initialize(padded);
            TestReader(reader, expected);
        }

        void TestReader(ISourceReader reader, string[] expected)
        {
            foreach (string str in expected)
            {
                Assert.IsFalse(reader.ReadingComplete);
                Assert.IsNotNull(reader.LastKeyword);
                Assert.AreEqual(str, reader.LastKeyword);
                reader.ReadNext();
            }
        }

        [TestMethod]
        public void TestReadingStrings()
        {

        }
    }
}
