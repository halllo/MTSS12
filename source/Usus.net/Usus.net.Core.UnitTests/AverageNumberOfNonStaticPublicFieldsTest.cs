using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageNumberOfNonStaticPublicFieldsTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_0NumberOfNonStaticPublicFields_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedNumberOfNonStaticPublicFields(), DELTA);
        }

        [TestMethod]
        public void Rate_4NumberOfNonStaticPublicFields_AverageRated50()
        {
            Assert.AreEqual(50.0, CreateAverage.RatedNumberOfNonStaticPublicFields(2, 2, 0, 0), DELTA);
        }
    }
}
