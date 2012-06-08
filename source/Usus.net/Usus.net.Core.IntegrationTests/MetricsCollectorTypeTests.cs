using andrena.Usus.net.Core.Verification;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.IntegrationTests
{
    [TestClass]
    public class MetricsCollectorTypeTests : MetricsCollectorTests
    {
        [TestMethod]
        public void Verify_NumberOfNonStaticPublicFields()
        {
            Verify.TypesWith<ExpectNumberOfNonStaticPublicFieldsAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NumberOfMethods()
        {
            Verify.TypesWith<ExpectNumberOfMethodsAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_DirectDependencies()
        {
            Verify.TypesWith<ExpectDirectDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NoDirectDependencies()
        {
            Verify.TypesWith<ExpectNoDirectDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_InterestingDependencies()
        {
            Verify.TypesWith<ExpectInterestingDirectDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NoInterestingDependencies()
        {
            Verify.TypesWith<ExpectNoInterestingDirectDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_CumulativeComponentDependencies()
        {
            Verify.TypesWith<ExpectCumulativeComponentDependencyAttribute>(metrics);
        }
    }
}
