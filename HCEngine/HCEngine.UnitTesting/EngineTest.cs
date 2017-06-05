using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HCEngine.UnitTesting
{
    [TestClass]
    public class EngineTest
    {
        static bool s_check = false;

        [ExposedCall(NameOverride = "testcheck")]
        public static void TestCheck()
        {
            s_check = true;
        }

        [TestMethod]
        public void TestEngine()
        {
            s_check = false;
            Engine e = new Engine();
            s_check = false;
            e.LoadAndRun("testcheck");
            Assert.IsTrue(s_check);
        }
    }
}
