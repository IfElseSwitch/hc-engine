using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace HCEngine.UnitTesting.EngineCore
{
    [ExposedType]
    public class FirstType { }

    [ExposedType(NameOverride = "Another")]
    public class SecondType { }

    [ExposedType(LinkToType = typeof(int))]
    public class ThirdType { }

    [ExposedType(LinkToType = typeof(bool), NameOverride = "BoolType")]
    public class FourthType { }

    [ExposedType(LinkToType = typeof(string), NameOverride = "String", ConstantReaderType = typeof(StringReader))]
    public class StringLink
    {
        class StringReader : IConstantReader
        {
            public bool Try(string word, out object instance)
            {
                instance = null;
                if (!word.StartsWith("\"") || !word.EndsWith("\""))
                    return false;
                instance = word.Substring(1,word.Length - 2);
                return true;
            }
        }
    }


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
            Assert.AreEqual(typeof(FirstType), t);

            Assert.IsFalse(scope.Contains("SecondType"));
            Assert.IsTrue(scope.Contains("Another"));
            Assert.IsTrue(scope.IsOfType<Type>("Another"));
            t = scope["Another"] as Type;
            Assert.IsNotNull(t);
            Assert.AreEqual(typeof(SecondType), t);

            Assert.IsFalse(scope.Contains("ThirdType"));
            Assert.IsTrue(scope.Contains("Int32"));
            Assert.IsTrue(scope.IsOfType<Type>("Int32"));
            t = scope["Int32"] as Type;
            Assert.IsNotNull(t);
            Assert.AreEqual(typeof(int), t);

            Assert.IsFalse(scope.Contains("FouthType"));
            Assert.IsTrue(scope.Contains("BoolType"));
            Assert.IsTrue(scope.IsOfType<Type>("BoolType"));
            t = scope["BoolType"] as Type;
            Assert.IsNotNull(t);
            Assert.AreEqual(typeof(bool), t);

            Assert.IsFalse(scope.Contains("StringLink"));
            Assert.IsTrue(scope.Contains("String"));
            Assert.IsTrue(scope.IsOfType<Type>("String"));
            t = scope["String"] as Type;
            Assert.IsNotNull(t);
            Assert.AreEqual(typeof(string), t);
            Assert.IsTrue(scope.Contains("cr:String"));
            IConstantReader cr = scope["cr:String"] as IConstantReader;
            Assert.IsNotNull(cr);
            object res;
            Assert.IsTrue(cr.Try("\"test\"", out res));
            Assert.AreEqual("test", res);

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
