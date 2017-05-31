using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HCEngine.Default;

namespace HCEngine.UnitTesting
{
    [TestClass]
    public class ScriptExecutionTest
    {
        [TestMethod]
        public void ExecutionTest()
        {
            IScriptExecution execution = new ScriptExecution(Execution());
            Assert.IsTrue(execution.IsAlive);
            Assert.AreEqual(0, execution.ExecuteNext());
            Assert.IsTrue(execution.IsAlive);
            Assert.IsNull(execution.ExecuteNext());
            Assert.IsTrue(execution.IsAlive);
            Assert.AreEqual("test", execution.ExecuteNext());
            Assert.IsTrue(execution.IsAlive);
            Assert.AreEqual(12.5f, execution.ExecuteNext());
        }

        IEnumerator<object> Execution()
        {
            yield return 0;
            yield return null;
            yield return "test";
            yield return 12.5f;
        }
    }
}
