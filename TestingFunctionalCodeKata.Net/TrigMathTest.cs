using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingFunctionalCodeKata.Net
{
    // Goal: achieve 100% test coverage

    [TestClass]
    public class TrigMathTest
    {
        private double Delta = 0.000001;

        [TestMethod]
        public void TestSin()
        {
            Assert.AreEqual(0.850903013525752, TrigMath.Sin(45), delta: Delta);
        }

    }
}