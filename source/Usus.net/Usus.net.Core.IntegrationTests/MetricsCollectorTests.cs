using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.ReflectionHelper;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorTests
    {
        static MetricsCollector metrics = new MetricsCollector();

        [TestInitialize]
        public void Ensure_MetricsReportIsAvailable()
        {
            if (metrics.Report == null) metrics.AnalyzeMe();
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

        [TestMethod]
        public void Verify_NoTypeDependencies()
        {
            Verify.MethodsWith<ExpectNoTypeDependencyAttribute>(metrics.Report);
        }

        [TestMethod]
        public void Verify_NumberOfStatements()
        {
            Verify.MethodsWith<ExpectNumberOfStatementsAttribute>(metrics.Report);
        }

        [TestMethod]
        public void Verify_NumberOfRealLines()
        {
            Verify.MethodsWith<ExpectNumberOfRealLinesAttribute>(metrics.Report);
        }

        [TestMethod]
        public void Verify_NumberOfLogicalLines()
        {
            Verify.MethodsWith<ExpectNumberOfLogicalLinesAttribute>(metrics.Report);
        }

        [TestMethod]
        public void PropertyGetterAndSetterFound()
        {
            var property = PropertyExtensions.GetPropertyInfo(() => MethodMetrics.MethodLengths.PropertyAutoImplemented);
            var propertyMetrics = metrics.Report.For(property);
            Assert.IsTrue(propertyMetrics.Getter != null);
            Assert.IsTrue(propertyMetrics.Setter != null);
        }
    }
}
