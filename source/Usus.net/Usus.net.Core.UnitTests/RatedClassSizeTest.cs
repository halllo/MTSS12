using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories.Metrics;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedClassSizeTest
    {
        private const double DELTA = 0.01;

        [TestMethod]
        public void Rate_ClassSize0_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.ClassSize(0), DELTA);
        }
        
        [TestMethod]
        public void Rate_ClassSize12_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.ClassSize(12), DELTA);
        }
        
        [TestMethod]
        public void Rate_ClassSize13_Rated8Point33()
        {
            Assert.AreEqual(8.33, CreateRated.ClassSize(13), DELTA);
        }
    }
}
