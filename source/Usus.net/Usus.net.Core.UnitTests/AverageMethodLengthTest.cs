using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageMethodLengthTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_0MethodLengths_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedMethodLength(), DELTA);
        }

        [TestMethod]
        public void Rate_1MethodLength10_AverageRated0()
        {
            Assert.AreEqual(11.11, CreateAverage.RatedMethodLength(10), DELTA);
        }

        [TestMethod]
        public void Rate_31MethodLengths_AverageRated1Point4()
        {
            Assert.AreEqual(1.4, CreateAverage.RatedMethodLength(
                13, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }
    }
}
