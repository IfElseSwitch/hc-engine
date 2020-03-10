using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HCEngine.DefaultImplementations;
using HCEngine.DefaultImplementations.Language;

namespace HCEngine.UnitTesting.DefaultLanguage
{
    [TestClass]
    public class InputSectionTest
    {
        static Dictionary<string, Type> s_OneParam = new Dictionary<string, Type>()
        {
            {"$x", typeof(int) }
        };

        static Dictionary<string, Type> s_TwoParam = new Dictionary<string, Type>()
        {
            {"$x", typeof(int) },
            {"$y", typeof(int) }
        };

        static Dictionary<string, Type> s_ListParam = new Dictionary<string, Type>()
        {
            {"$list", typeof(List<int>) }
        };

        IExecutionScope m_Scope = new ScopeFactory().MakeScope();

        [TestMethod]
        public void TestInputSection()
        {
            TestInput<InputSection>("input $x is Int", false, s_OneParam);
            TestInput<InputSection>("input ( $x is Int $y is Int )", false, s_TwoParam);
            TestInput<InputSection>("input $x is Int $y is Int", false, s_OneParam, "$y");
            TestInput<InputSection>("input ( $x is Int $y is Int ) $z", false, s_TwoParam, "$z");
            TestInput<InputSection>("( $x is Int $y is Int )", true, null);
            TestInput<InputSection>("$x is Int", true, null);
        }

        [TestMethod]
        public void TestDeclarationList()
        {
            TestInput<DeclarationList>("( $x is Int )", false, s_OneParam);
            TestInput<DeclarationList>("( $x is Int $y is Int )", false, s_TwoParam);
            TestInput<DeclarationList>("( $x is $y is Int )", true, null);
            TestInput<DeclarationList>("( $x is Int $y )", true, null);
            TestInput<DeclarationList>("( $x is Int $y is Int ) $z", false, s_TwoParam, "$z");
            TestInput<DeclarationList>("$x is Int $y is Int", true, null);
        }

        [TestMethod]
        public void TestInputDeclaration()
        {
            TestInput<InputDeclaration>("$x is Int", false, s_OneParam);
            TestInput<InputDeclaration>("$x Int", true, null);
            TestInput<InputDeclaration>("$x is", true, null);
            TestInput<InputDeclaration>("is Int", true, null);
            TestInput<InputDeclaration>("x is Int", true, null);
            TestInput<InputDeclaration>("Int", true, null);
            TestInput<InputDeclaration>("$x $y is Int", true, null);
            TestInput<InputDeclaration>("$x is Int $y is Int", false, s_OneParam, "$y");
            TestInput<InputDeclaration>("$x is Int $y", false, s_OneParam, "$y");
        }

        [TestMethod]
        public void TestGenericTypeInputDeclaration()
        {
            TestInput<InputDeclaration>("$list is List of Int", false, s_ListParam);
            TestInput<InputDeclaration>("$list List Int", true, null);
            TestInput<InputDeclaration>("$list is List Int", true, null);
            TestInput<InputDeclaration>("$list is of Int", true, null);
        }


        void TestInput<TInput>(string code, bool expectError, IDictionary<string, Type> expectedParameters, string unexpectedName = null)
            where TInput : ISyntaxTreeItem, new()
        {
            ISourceReader reader = new SourceReader();
            reader.Initialize(code);
            TInput tested = new TInput();
            try
            {
                var exec = tested.Execute(reader, m_Scope, false);
                var pmap = exec.ExecuteNext() as IDictionary<string, Type>;

                Assert.IsFalse(expectError);
                foreach (var kvp in expectedParameters)
                {
                    Assert.IsTrue(pmap.ContainsKey(kvp.Key));
                    Assert.AreEqual(kvp.Value, pmap[kvp.Key]);
                }
                if (!string.IsNullOrEmpty(unexpectedName))
                    Assert.IsFalse(pmap.ContainsKey(unexpectedName));
            }
            catch (SyntaxException se)
            {
                se.RemoveUnusedWarning();
                Assert.IsTrue(expectError, se.Message);
            }

        }
    }
}
