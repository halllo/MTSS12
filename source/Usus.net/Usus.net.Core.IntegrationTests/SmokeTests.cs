using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class SmokeTests
    {
        static MetricsCollector metrics = new MetricsCollector();

        [TestInitialize]
        public void Ensure_MetricsReportIsAvailable()
        {
            if (metrics.Report == null) metrics.AnalyzeMe();
        }

        [TestMethod]
        public void JustTryStuffOut()
        {
            Assert.IsTrue(true);
        }
    }
}
