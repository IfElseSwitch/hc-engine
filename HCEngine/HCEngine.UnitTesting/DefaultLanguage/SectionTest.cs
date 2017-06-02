using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;
using HCEngine.Default.Language;


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
            TestSection<If>("if false testwrong else testcall", true, typeof(ScopeException), null);
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
                    Assert.AreEqual(execTrace[i++], o);
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
