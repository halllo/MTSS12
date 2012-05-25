using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedMetricsTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_0CyclomaticComplexities_AverageRated0()
        {
            Assert.AreEqual(0.0, Create.AverageRatedCyclomaticComplexity(), DELTA);
        }

        [TestMethod]
        public void Rate_1CyclomaticComplexity5_AverageRated0()
        {
            Assert.AreEqual(25.0, Create.AverageRatedCyclomaticComplexity(5), DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith5_AverageRatedPoint8()
        {
            Assert.AreEqual(0.8, Create.AverageRatedCyclomaticComplexity(
                5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith6_AverageRated1Point6()
        {
            Assert.AreEqual(1.6, Create.AverageRatedCyclomaticComplexity(
                6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }

        [TestMethod]
        public void Rate_0MethodLengths_AverageRated0()
        {
            Assert.AreEqual(0.0, Create.AverageRatedMethodLength(), DELTA);
        }

        [TestMethod]
        public void Rate_1MethodLength10_AverageRated0()
        {
            Assert.AreEqual(11.11, Create.AverageRatedMethodLength(10), DELTA);
        }

        [TestMethod]
        public void Rate_31MethodLengths_AverageRated1Point4()
        {
            Assert.AreEqual(1.4, Create.AverageRatedMethodLength(
                13, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }
    }
}
