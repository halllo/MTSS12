using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class OpenSourceSoftwareAnalysis : FolderAnalysis
    {
        [TestMethod]
        public void AnalyzeFolders()
        {
            //AnalyzeFolder("CciAst");
            //AnalyzeFolder("CciMetadata");
            //AnalyzeFolder("GraphSharp");
            //AnalyzeFolder("QuickGraph");
            //AnalyzeFolder("Usus.net");
            //AnalyzeFolder("Usus.net ohne pdb");
        }

        private void AnalyzeFolder(string folder)
        {
            Console.WriteLine("Sequential");
            OutputAnalysisTimes(folder, AnalyzeAssembliesIn(Samples.Folder + folder));
            Console.WriteLine("Parallel");
            OutputAnalysisTimes(folder, AnalyzeInParallelAssembliesIn(Samples.Folder + folder));
        }
    }
}