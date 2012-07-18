using andrena.Usus.net.Core.Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class DistributionFittingTests
    {
        [TestMethod]
        public void FitExponentialDistribution_3Methods321Lines_LambdaPoint5()
        {
            var distribution = CreateDistribution.ForMethodLengths(1, 2, 3);
            Assert.AreEqual(0.5, distribution.FitExponentialDistribution(), Constants.DELTA);
        }

        [TestMethod]
        public void FitExponentialDistribution_3Methods321Lines_WorseThan111()
        {
            var distributionBad = CreateDistribution.ForMethodLengths(1, 2, 3);
            var distributionGood = CreateDistribution.ForMethodLengths(1, 1, 1);
            Assert.IsTrue(
                distributionBad.FitExponentialDistribution() < 
                distributionGood.FitExponentialDistribution());
        }
    }
}
