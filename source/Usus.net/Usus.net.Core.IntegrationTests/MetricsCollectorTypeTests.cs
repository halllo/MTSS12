using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorTypeTests : MetricsCollectorTests
    {
        [TestMethod]
        public void MetricsForTypes_TypeWithPublicFields_Found()
        {
            //TODO: verification on types
            var report = metrics.Types;
            Assert.IsTrue(report != null);
        }
    }
}
