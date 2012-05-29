using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.UnitTests
{
    [TestClass]
    public class HotspotsTest
    {
        [TestMethod]
        public void Hotspots_3CyclomaticComplexities1OverLimit_1Hotspot()
        {
            var hotspots = Create.CyclomaticComplexityHotspots(2, 4, 5);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_3CyclomaticComplexitiesNoOverLimit_NoHotspot()
        {
            var hotspots = Create.CyclomaticComplexityHotspots(2, 4, 4);
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_NoCyclomaticComplexities_NoHotspot()
        {
            var hotspots = Create.CyclomaticComplexityHotspots();
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_3MethodLengths1OverLimit_1Hotspot()
        {
            var hotspots = Create.MethodLengthHotspots(2, 9, 10);
            Assert.IsTrue(hotspots.Count() == 1);
        }

        [TestMethod]
        public void Hotspots_3MethodLengthsNoOverLimit_NoHotspot()
        {
            var hotspots = Create.MethodLengthHotspots(2, 9, 9);
            Assert.IsTrue(hotspots.Count() == 0);
        }

        [TestMethod]
        public void Hotspots_NoMethodLengths_NoHotspot()
        {
            var hotspots = Create.MethodLengthHotspots();
            Assert.IsTrue(hotspots.Count() == 0);
        }
    }
}
