using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;
using HCEngine.Default.Language;
using System.Collections.Generic;
using System.Collections;
using HCEngine.Default.Built_in;

namespace HCEngine.UnitTesting.DefaultLanguage
{
    [TestClass]
    public class SectionTest
    {
        IExecutionScope m_Scope = new ScopeFactory().MakeScope();

        [TestMethod]
        public void TestIf()
        {
            TestSection<If>("if true testcall", false, null, true, "OK");
            TestSection<If>("if false testcall", false, null, false);
            TestSection<If>("if false testcall else testargs 2", false, null, false, 2, 2);
            TestSection<If>("if false testargs \"OK\" else testcall", false, null, false, "OK");
            TestSection<If>("if testcall testargs 2", true, typeof(OperationException), null);
            TestSection<If>("if false testargs $z else testcall", false, null, false, "OK");
            TestSection<If>("if false testwrong else testcall", true, typeof(SyntaxException), null);
        }

        [TestMethod]
        public void TestLoop()
        {
            TestSection<Loop>("loop $i in range 2\n testargs $i", false, null,
                2,
                Calls.Range(2) as ICollection, 
                null,
                true,
                "$i",
                0, 
                0,
                null,
                true,
                "$i",
                1,
                1,
                false
                );
            TestSection<Loop>("loop while false testargs $z", false, null, false, false);
        }

        void TestSection<TSection>(string source, bool expectError, Type expectedError, params object[] execTrace)
            where TSection : ISyntaxTreeItem, new()
        {
            ISourceReader reader = new SourceReader();
            reader.Initialize(source);
            TSection section = new TSection();
            try
            {
                var exec = section.Execute(reader, m_Scope, false);
                int i = 0;
                foreach(object o in exec)
                {
                    if (expectError)
                        continue;
                    Assert.IsTrue(i < execTrace.Length);
                    object expected = execTrace[i++];
                    if (expected is IList)
                    {
                        Assert.IsInstanceOfType(o, typeof(IList));
                        IList collection = expected as IList;
                        IList actual = o as IList;
                        for(int j = 0; j < collection.Count; ++j)
                        {
                            Assert.IsTrue(j < actual.Count);
                            Assert.AreEqual(collection[j], actual[j]);
                        }
                    }
                    else
                        Assert.AreEqual(expected, o);
                }
                Assert.IsFalse(expectError);
                Assert.AreEqual(execTrace.Length, i);
            }
            catch (HCEngineException he)
            {
                Assert.IsTrue(expectError && expectedError.IsAssignableFrom(he.GetType()));
            }
        }
    }
}
