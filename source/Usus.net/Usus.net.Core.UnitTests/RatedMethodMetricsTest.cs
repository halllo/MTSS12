using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedMethodMetricsTest
    {
        private const double DELTA = 0.1;

        [TestMethod]
        public void Rate_CyclomaticComplexity0_Rated0()
        {
            Assert.AreEqual(0.0, Create.RatedCyclomaticComplexity(0));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexityMinus1_Rated0()
        {
            Assert.AreEqual(0.0, Create.RatedCyclomaticComplexity(-1));
        }

        [TestMethod]
        public void Rate_CyclomaticComplexity3_Rated0()
        {
            Assert.AreEqual(0.0, Create.RatedCyclomaticComplexity(3));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexity4_Rated0()
        {
            Assert.AreEqual(0.0, Create.RatedCyclomaticComplexity(4));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexity5_RatedPoint25()
        {
            Assert.AreEqual(0.25, Create.RatedCyclomaticComplexity(5));
        }

        [TestMethod]
        public void Rate_MethodLengthMinus1_Rated0()
        {
            Assert.AreEqual(0, Create.RatedMethodLength(-1));
        }

        [TestMethod]
        public void Rate_MethodLengthMinus1_FallbackToStatementsRated10()
        {
            Assert.AreEqual(0.111111, Create.RatedMethodLength(-1, 10), DELTA);
        }

        [TestMethod]
        public void Rate_MethodLength0_Rated0()
        {
            Assert.AreEqual(0, Create.RatedMethodLength(0));
        }

        [TestMethod]
        public void Rate_MethodLength9_Rated0()
        {
            Assert.AreEqual(0, Create.RatedMethodLength(9));
        }

        [TestMethod]
        public void Rate_MethodLength10_RatedPoint1111()
        {
            Assert.AreEqual(0.111111, Create.RatedMethodLength(10), DELTA);
        }
    }
}
