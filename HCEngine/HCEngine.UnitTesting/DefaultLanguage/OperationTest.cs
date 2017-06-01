using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;
using HCEngine.Default.Language;
using HCEngine.Default.Language.Statements;

namespace HCEngine.UnitTesting.DefaultLanguage
{
    [TestClass]
    public class OperationTest
    {
        IExecutionScope m_Scope = new ScopeFactory().MakeScope();

        [TestMethod]
        public void TestConstant()
        {
        }

        [TestMethod]
        public void TestCall()
        {

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
            where TOperation : AOperation, new()
        {
            ISourceReader reader = new SourceReader();
            reader.Initialize(source);
            TOperation op = new TOperation();
            try
            {
                op.Setup(reader, m_Scope);
                Assert.IsFalse(expectError && expectedErrorType.IsAssignableFrom(typeof(SyntaxException)));
                
            }
            catch (HCEngineException he)
            {
                Assert.IsTrue(expectError && expectedErrorType.IsAssignableFrom(he.GetType()));
                return;
            }

            try
            {
                var exec = op.Execute(m_Scope);
                object lastValue = null;
                foreach(var o in exec)
                {
                    lastValue = o;
                }
                Assert.IsFalse(expectError && typeof(ExecutionException).IsAssignableFrom(expectedErrorType));
                Assert.AreEqual(expectedValue, lastValue);
            }
            catch (HCEngineException he)
            {
                Assert.IsTrue(expectError && expectedErrorType.IsAssignableFrom(he.GetType()));
            }
        }
    }
}
