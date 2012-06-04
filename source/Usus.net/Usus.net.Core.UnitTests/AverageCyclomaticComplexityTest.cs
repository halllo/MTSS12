using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class AverageCyclomaticComplexityTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_0CyclomaticComplexities_AverageRated0()
        {
            Assert.AreEqual(0.0, CreateAverage.RatedCyclomaticComplexity(), DELTA);
        }

        [TestMethod]
        public void Rate_1CyclomaticComplexity5_AverageRated0()
        {
            Assert.AreEqual(25.0, CreateAverage.RatedCyclomaticComplexity(5), DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith5_AverageRatedPoint8()
        {
            Assert.AreEqual(0.8, CreateAverage.RatedCyclomaticComplexity(
                5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }

        [TestMethod]
        public void Rate_31CyclomaticComplexitiesOneWith6_AverageRated1Point6()
        {
            Assert.AreEqual(1.6, CreateAverage.RatedCyclomaticComplexity(
                6, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1), DELTA);
        }
    }
}
