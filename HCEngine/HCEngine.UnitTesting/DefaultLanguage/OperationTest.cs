using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;
using HCEngine.Default.Language;

namespace HCEngine.UnitTesting.DefaultLanguage
{
    
    [TestClass]
    public class OperationTest
    {
        IExecutionScope m_Scope = new ScopeFactory().MakeScope();

        [ExposedCall(NameOverride = "testcall")]
        public static string TestCallMethod() { return "OK"; }

        [ExposedCall(NameOverride = "testargs")]
        public static int TestArgs(int arg) { return arg; }

        [TestMethod]
        public void TestConstant()
        {
            TestOperation<Constant>("1", false, 1, null);
            TestOperation<Constant>("\"the cat\"", false, "the cat", null);
            TestOperation<Constant>("[wrong]", true, null, typeof(SyntaxException));
        }

        [TestMethod]
        public void TestCall()
        {
            m_Scope["$x"] = 1;
            TestOperation<Call>("testcall", false, "OK", null);
            TestOperation<Call>("testargs $x", false, 1, null);
            TestOperation<Call>("testwrong", true, null, typeof(ScopeException));
            TestOperation<Call>("testcall $x", false, "OK", null);
            TestOperation<Call>("testargs", true, null, typeof(SyntaxException));
            TestOperation<Call>("testargs 2", false, 2, null);
        }

        [TestMethod]
        public void TestVariable()
        {
            m_Scope["$x"] = 1;
            TestOperation<Variable>("$x", false, 1, null);
            TestOperation<Variable>("$y", true, null, typeof(ScopeException));
            TestOperation<Variable>("$x y", false, 1, null);
            TestOperation<Variable>("x", true, null, typeof(SyntaxException));
        }


        void TestOperation<TOperation>(string source, bool expectError, object expectedValue, Type expectedErrorType)
            where TOperation : ISyntaxTreeItem, new()
        {
            ISourceReader reader = new SourceReader();
            reader.Initialize(source);
            TOperation op = new TOperation();
            try
            {
                var exec = op.Execute(reader, m_Scope);
                object lastValue = null;
                foreach (var o in exec)
                {
                    lastValue = o;
                }
                Assert.IsFalse(expectError);
                Assert.AreEqual(expectedValue, lastValue);
            }
            catch (HCEngineException he)
            {
                Assert.IsTrue(expectError && expectedErrorType.IsAssignableFrom(he.GetType()));
                return;
            }
        }
    }
}
