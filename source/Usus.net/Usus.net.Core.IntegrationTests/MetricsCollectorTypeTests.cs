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
    }
}
