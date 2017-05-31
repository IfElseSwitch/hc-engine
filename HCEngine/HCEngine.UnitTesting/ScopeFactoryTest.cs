using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace HCEngine.UnitTesting
{
    [TestClass]
    public class ScopeFactoryTest
    {
        [TestMethod]
        public void DefaultScopeFactoryTest()
        {
            IScopeFactory factory = new Default.ScopeFactory();
            IExecutionScope scope = factory.MakeScope();
            Assert.IsTrue(scope.Contains("firstMethod"));
            Assert.IsTrue(scope.IsOfType<MethodInfo>("firstMethod"));
            var method = scope["firstMethod"] as MethodInfo;
            Assert.IsNotNull(method);
            Assert.AreEqual("OK", method.Invoke(null, new object[0]));
            Assert.IsFalse(scope.Contains("secondMethod"));
        }

        [ExposedCall]
        public static string FirstMethod()
        {
            return "OK";
        }
    }
}
