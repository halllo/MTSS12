using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class DistributionTests
    {
        [TestMethod]
        public void MethodDistribution_MethodWithZeroLines_OneElementAtZero()
        {
            var distribution = CreateDistribution.ForMethodLengths(1);
            Assert.AreEqual(2, distribution.BinCount);
            Assert.AreEqual(1, distribution.ElementsInBin(1));
        }

        [TestMethod]
        public void MethodDistribution_MethodWith2Lines_OneElementAtTwo()
        {
            var distribution = CreateDistribution.ForMethodLengths(2);
            Assert.AreEqual(3, distribution.BinCount);
            Assert.AreEqual(0, distribution.ElementsInBin(0));
            Assert.AreEqual(0, distribution.ElementsInBin(1));
            Assert.AreEqual(1, distribution.ElementsInBin(2));
        }

        [TestMethod]
        public void MethodDistribution_TwoMethodWith2Lines_TwoElementAtTwo()
        {
            var distribution = CreateDistribution.ForMethodLengths(2, 2);
            Assert.AreEqual(3, distribution.BinCount);
            Assert.AreEqual(0, distribution.ElementsInBin(0));
            Assert.AreEqual(0, distribution.ElementsInBin(1));
            Assert.AreEqual(2, distribution.ElementsInBin(2));
        }

        [TestMethod]
        public void MethodDistribution_TwoMethodWith1And2Lines_OneElementAtEach()
        {
            var distribution = CreateDistribution.ForMethodLengths(1, 2);
            Assert.AreEqual(3, distribution.BinCount);
            Assert.AreEqual(0, distribution.ElementsInBin(0));
            Assert.AreEqual(1, distribution.ElementsInBin(1));
            Assert.AreEqual(1, distribution.ElementsInBin(2));
        }
    }
}
