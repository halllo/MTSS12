using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsEngineTests
    {
        MetricsEngine metrics;

        [TestInitialize]
        public void Setup()
        {
            metrics = new MetricsEngine();
            metrics.AnalyzeMe();
        }

        [TestMethod]
        public void Verify_CyclomaticComplexities()
        {
            Verify.MethodsWith<ExpectCyclomaticComplexityAttribute>(metrics.Report);
        }

        [TestMethod]
        public void Verify_TypeDependencies()
        {
            Verify.MethodsWith<ExpectTypeDependencyAttribute>(metrics.Report);
        }
    }
}
