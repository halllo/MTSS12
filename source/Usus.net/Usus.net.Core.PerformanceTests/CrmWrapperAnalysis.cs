using Microsoft.VisualStudio.TestTools.UnitTesting;
using andrena.Usus.net.Core.Prepared;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class CrmWrapperAnalysis : FolderAnalysis
    {
        [TestMethod]
        public void AnalyzeRichardsCode()
        {
            var report = AnalyzeAssembliesIn(@"Z:\temp\4manuel");
            var crmWrapper = new PreparedMetricsFactory().Prepare(report);
            Assert.IsNotNull(crmWrapper);
        }    
    }
}