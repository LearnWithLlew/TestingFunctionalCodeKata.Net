using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingFunctionalCodeKata.Net
{
    // Goal: achieve 100% test coverage

    [TestClass]
    public class TrigMathTest
    {
        [TestMethod]
        public void TestSin()
        {
            Assert.AreEqual(0, TrigMath.Sin(45));
        }

    }
}