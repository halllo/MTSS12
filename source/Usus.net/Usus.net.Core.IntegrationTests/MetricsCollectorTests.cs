using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorTests
    {
        static MetricsReport metrics;

        [TestInitialize]
        public void Ensure_MetricsReportIsAvailable()
        {
            if (metrics == null) metrics = Analyze.Me();
        }

        [TestMethod]
        public void Verify_CyclomaticComplexities()
        {
            Verify.MethodsWith<ExpectCyclomaticComplexityAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_TypeDependencies()
        {
            Verify.MethodsWith<ExpectTypeDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NoTypeDependencies()
        {
            Verify.MethodsWith<ExpectNoTypeDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NumberOfStatements()
        {
            Verify.MethodsWith<ExpectNumberOfStatementsAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NumberOfRealLines()
        {
            Verify.MethodsWith<ExpectNumberOfRealLinesAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NumberOfLogicalLines()
        {
            Verify.MethodsWith<ExpectNumberOfLogicalLinesAttribute>(metrics);
        }

        [TestMethod]
        public void MetricsForProperty_AutoImplementedPropertyGetterAndSetter_Found()
        {
            var propertyMetrics = metrics.ForProperty(() => MethodMetrics.MethodLengths.PropertyAutoImplemented);
            Assert.IsTrue(propertyMetrics.Getter != null);
            Assert.IsTrue(propertyMetrics.Setter != null);
        }

        [TestMethod]
        public void MetricsForProperty_PropertyGetterNoSetter_Found()
        {
            var propertyMetrics = metrics.ForProperty(() => MethodMetrics.MethodLengths.PropertyGetterWithLogic);
            Assert.IsTrue(propertyMetrics.Getter != null);
            Assert.IsTrue(propertyMetrics.Setter == null);
        }

        [TestMethod]
        public void MetricsForMethod_MethodWithReturnValue_Found()
        {
            var report = metrics.ForMethod(() => MethodMetrics.TypeDependencies.MethodWithNoGenericsInSignature(null));
            Assert.IsTrue(report != null);
        }
    }
}
