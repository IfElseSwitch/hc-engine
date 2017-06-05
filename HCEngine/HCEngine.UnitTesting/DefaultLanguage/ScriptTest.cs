using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCEngine.Default;
using System.Collections.Generic;

namespace HCEngine.UnitTesting.DefaultLanguage
{
    [TestClass]
    public class ScriptTest
    {
        [TestMethod]
        public void TestScript()
        {
            ISourceReader reader = new SourceReader();
            IExecutionScope scope = new ScopeFactory().MakeScope();
            reader.Initialize("input ( \n $x is Int \n ) \n if inf $x 2 ( \n testcall \n ) \n else ( \n testargs $x \n )");
            IScript script = new Script(reader, scope);
            TestScript(script, new Dictionary<string, object>() { {"$x", 1 } }, false, "OK");
            TestScript(script, new Dictionary<string, object>() { {"$x", 2 } }, false, 2);
            TestScript(script, new Dictionary<string, object>() { {"$y", 1 } }, true, null);
            TestScript(script, new Dictionary<string, object>() { {"$x", true } }, true, null);
            TestScript(script, new Dictionary<string, object>() { {"$x", 1 }, { "$y", true } }, false, "OK");
        }

        private void TestScript(IScript script, IDictionary<string, object> parameters, bool expectError, object lastValue)
        {
            try
            {
                var exec = script.Run(parameters);
                object last = null;
                foreach (object o in exec)
                    last = o;
                Assert.IsFalse(expectError);
                Assert.AreEqual(lastValue, last);
            }
            catch (HCEngineException he)
            {
                he.RemoveUnusedWarning();
                Assert.IsTrue(expectError, he.Message);
            }
        }
    }
}
