using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageClassSizeTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_0ClassSizes_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedClassSize(), DELTA);
        }

        [TestMethod]
        public void Rate_4ClassSizes_AverageRated8Point3()
        {
            Assert.AreEqual(8.3, CreateAverage.RatedClassSize(5, 13, 15, 1), DELTA);
        }
    }
}
