using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace HCEngine.UnitTesting
{
    [ExposedType]
    public class FirstType { }

    [ExposedType(NameOverride = "Another")]
    public class SecondType { }

    [ExposedType(LinkToType = typeof(int))]
    public class ThirdType { }

    [ExposedType(LinkToType = typeof(bool), NameOverride = "BoolType")]
    public class FourthType { }

    [TestClass]
    public class ScopeFactoryTest
    {
        [TestMethod]
        public void ScopeFactoryCallsTest()
        {
            IScopeFactory factory = new Default.ScopeFactory();
            IExecutionScope scope = factory.MakeScope();
            Assert.IsTrue(scope.Contains("firstMethod"));
            Assert.IsTrue(scope.IsOfType<MethodInfo>("firstMethod"));
            var method = scope["firstMethod"] as MethodInfo;
            Assert.IsNotNull(method);
            Assert.AreEqual("OK", method.Invoke(null, new object[0]));
            Assert.IsFalse(scope.Contains("secondMethod"));
            Assert.IsTrue(scope.Contains("second"));
            Assert.IsTrue(scope.IsOfType<MethodInfo>("second"));
            method = scope["second"] as MethodInfo;
            Assert.IsNotNull(method);
            Assert.AreEqual("OKI", method.Invoke(null, new object[0]));
        }

        [TestMethod]
        public void ScopeFactoryTypesTest()
        {
            IScopeFactory factory = new Default.ScopeFactory();
            IExecutionScope scope = factory.MakeScope();
            Assert.IsTrue(scope.Contains("FirstType"));
            Assert.IsTrue(scope.IsOfType<Type>("FirstType"));
            Type t = scope["FirstType"] as Type;
            Assert.IsNotNull(t);
            Assert.Equals(typeof(FirstType), t);

            Assert.IsFalse(scope.Contains("SecondType"));
            Assert.IsTrue(scope.Contains("Another"));
            Assert.IsTrue(scope.IsOfType<Type>("Another"));
            t = scope["Another"] as Type;
            Assert.IsNotNull(t);
            Assert.Equals(typeof(SecondType), t);

            Assert.IsFalse(scope.Contains("ThirdType"));
            Assert.IsTrue(scope.Contains("Int32"));
            Assert.IsTrue(scope.IsOfType<Type>("Int32"));
            t = scope["Int32"] as Type;
            Assert.IsNotNull(t);
            Assert.Equals(typeof(int), t);

            Assert.IsFalse(scope.Contains("FouthType"));
            Assert.IsTrue(scope.Contains("BoolType"));
            Assert.IsTrue(scope.IsOfType<Type>("BoolType"));
            t = scope["BoolType"] as Type;
            Assert.IsNotNull(t);
            Assert.Equals(typeof(bool), t);
        }

        [ExposedCall]
        public static string FirstMethod()
        {
            return "OK";
        }

        [ExposedCall(NameOverride = "second")]
        public static string SecondMethod()
        {
            return "OKI";
        }
    }
}
