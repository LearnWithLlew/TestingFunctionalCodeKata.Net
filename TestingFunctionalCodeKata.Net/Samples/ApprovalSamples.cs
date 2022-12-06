using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingFunctionalCodeKata.Net.Samples
{
    [TestClass]
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalSamples
    {
        [TestMethod]
        public void TestVerifyAll()
        {
            Approvals.VerifyAll("sin", new[] { 0.1 }, d => $"sin({d}) = {TrigMath.Sin(d)} ");
        }
    }
}
