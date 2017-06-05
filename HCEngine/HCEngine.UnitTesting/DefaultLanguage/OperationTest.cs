using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.DefaultImplementations;
using HCEngine.DefaultImplementations.Language;

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
            TestOperation<ConstantSyntax>("1", false, 1, null);
            TestOperation<ConstantSyntax>("\"the cat\"", false, "the cat", null);
            TestOperation<ConstantSyntax>("[wrong]", true, null, typeof(SyntaxException));
        }

        [TestMethod]
        public void TestCall()
        {
            m_Scope["$x"] = 1;
            TestOperation<CallSyntax>("testcall", false, "OK", null);
            TestOperation<CallSyntax>("testargs $x", false, 1, null);
            TestOperation<CallSyntax>("testwrong", true, null, typeof(ScopeException));
            TestOperation<CallSyntax>("testcall $x", false, "OK", null);
            TestOperation<CallSyntax>("testargs", true, null, typeof(SyntaxException));
            TestOperation<CallSyntax>("testargs 2", false, 2, null);
            TestOperation<CallSyntax>("testargs \"OK\"", true, null, typeof(OperationException));
        }

        [TestMethod]
        public void TestVariable()
        {
            m_Scope["$x"] = 1;
            TestOperation<VariableSyntax>("$x", false, 1, null);
            TestOperation<VariableSyntax>("$y", true, null, typeof(ScopeException));
            TestOperation<VariableSyntax>("$x y", false, 1, null);
            TestOperation<VariableSyntax>("x", true, null, typeof(SyntaxException));
        }

        [TestMethod]
        public void TestAssignation()
        {
            IExecutionScope assignScope = m_Scope.MakeSubScope();
            assignScope["$x"] = 1;

            AssignSubTest("set $x 2", assignScope, "$x", 2, "$y");
            AssignSubTest("set $y 1", assignScope, "$y", 1, "$z");
            try
            {
                AssignSubTest("set 2 $y", assignScope, "$x", 2, "$z");
                Assert.Fail("set 2 $y should throw syntax exception");
            }
            catch(SyntaxException se)
            {
                se.RemoveUnusedWarning();
            }
        }

        void AssignSubTest(string source, IExecutionScope scope, string expectedId, object expectedValue, string unexpectedId)
        {
            ISourceReader reader = new SourceReader();

            reader.Initialize(source);
            AssignationSyntax assign = new AssignationSyntax();

            var exec = assign.Execute(reader, scope, false);
            object[] expected = new object[] { expectedValue, null };
            int i = 0;
            foreach (object o in exec)
            {
                Assert.AreEqual(expected[i++], o);
            }

            Assert.IsTrue(scope.Contains(expectedId));
            Assert.AreEqual(expectedValue, scope[expectedId]);
            Assert.IsFalse(scope.Contains(unexpectedId));
        }

        void TestOperation<TOperation>(string source, bool expectError, object expectedValue, Type expectedErrorType)
            where TOperation : ISyntaxTreeItem, new()
        {
            ISourceReader reader = new SourceReader();
            reader.Initialize(source);
            TOperation op = new TOperation();
            try
            {
                var exec = op.Execute(reader, m_Scope, false);
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
