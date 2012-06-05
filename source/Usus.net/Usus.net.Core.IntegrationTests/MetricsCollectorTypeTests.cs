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
        public void Verify_Dependencies()
        {
            Verify.TypesWith<ExpectDirectDependencyAttribute>(metrics);
        }

        [TestMethod]
        public void Verify_NoDependencies()
        {
            Verify.TypesWith<ExpectNoDirectDependencyAttribute>(metrics);
        }
    }
}
