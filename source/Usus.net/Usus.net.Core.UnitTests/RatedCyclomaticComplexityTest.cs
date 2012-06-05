using Microsoft.VisualStudio.TestTools.UnitTesting;
using Usus.net.Core.UnitTests.Factories;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class RatedCyclomaticComplexityTest
    {
        [TestMethod]
        public void Rate_CyclomaticComplexity0_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.CyclomaticComplexity(0));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexityMinus1_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.CyclomaticComplexity(-1));
        }

        [TestMethod]
        public void Rate_CyclomaticComplexity3_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.CyclomaticComplexity(3));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexity4_Rated0()
        {
            Assert.AreEqual(0.0, CreateRated.CyclomaticComplexity(4));
        }
        
        [TestMethod]
        public void Rate_CyclomaticComplexity5_Rated25()
        {
            Assert.AreEqual(25.0, CreateRated.CyclomaticComplexity(5));
        }
    }
}
