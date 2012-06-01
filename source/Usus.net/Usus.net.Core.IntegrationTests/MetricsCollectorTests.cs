using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    public class MetricsCollectorTests
    {
        protected static MetricsReport metrics;

        [TestInitialize]
        public void Ensure_MetricsReportIsAvailable()
        {
            if (metrics == null) metrics = Analyze.Me();
        }
    }
}