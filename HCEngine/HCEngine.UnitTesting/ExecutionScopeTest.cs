using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;

namespace HCEngine.UnitTesting
{
    [TestClass]
    public class ExecutionScopeTest
    {
        [TestMethod]
        public void TestDefaultScope()
        {
            IExecutionScope scope = new ExecutionScope();
            TestScope(scope, "x", "y", "test");
            TestSubScope(scope, "x", "y", "test");
        }

        void TestScope(IExecutionScope scope, string intName, string wrongName, string delegateName)
        {
            TestAccess(scope, intName, wrongName, delegateName);
            // At this point, scope contains intName and delegateName
            TestContains(scope, intName, wrongName, delegateName);
            TestIsOfType(scope, intName, wrongName, delegateName);
        }

        void TestSubScope(IExecutionScope scope, string intName, string wrongName, string delegateName)
        {
            IExecutionScope subscope = scope.MakeSubScope();
            TestScope(subscope, "sub" + intName, "sub" + wrongName, "sub" + delegateName);
            TestContains(subscope, intName, wrongName, delegateName);
            TestIsOfType(subscope, intName, wrongName, delegateName);
        }

        void TestAccess(IExecutionScope scope, string intName, string wrongName, string delegateName)
        {
            scope[intName] = 1;
            Assert.AreEqual(1, scope[intName]);
            try
            {
                object b = scope[wrongName];
                Assert.Fail("Accessing a wrong name should throw an error");
            }
            catch(ScopeException se)
            {}
            catch
            {
                Assert.Fail("Unknown error thrown when accessing wrong name");
            }
            Func<object> test = () => new object();
            scope[delegateName] = test;
            try
            {
                object o = ( (Func<object>) scope[delegateName] )();
                if (o == null)
                    Assert.Fail("stored delegate returned null");
            }
            catch
            {
                Assert.Fail("Stored delegate not of right type");
            }
        }
        
        void TestContains(IExecutionScope scope, string intName, string wrongName, string delegateName)
        {
            Assert.IsTrue(scope.Contains(intName));
            Assert.IsFalse(scope.Contains(wrongName));
            Assert.IsTrue(scope.Contains(delegateName));
        }

        void TestIsOfType(IExecutionScope scope, string intName, string wrongName, string delegateName)
        {
            Assert.IsTrue(scope.IsOfType<int>(intName));
            Assert.IsFalse(scope.IsOfType<string>(intName));
            Assert.IsFalse(scope.IsOfType<object>(wrongName));
            Assert.IsTrue(scope.IsOfType<Func<object>>(delegateName));
            Assert.IsFalse(scope.IsOfType<string>(delegateName));
        }

    }
}
