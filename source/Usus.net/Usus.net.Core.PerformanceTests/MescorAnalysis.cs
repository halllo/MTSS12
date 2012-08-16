using System;
using andrena.Usus.net.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Usus.net.Core.PerformanceTests
{
    [TestClass]
    public class MescorAnalysis : FolderAnalysis
    {
        #region Libraries
        private string[] _libraries = new string[]
                                 {
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Mescor.Contracts.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Contracts.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\NetBridge.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.ResearchBrowser.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.ResearchBrowser.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.UnternehmenStammdaten.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.UnternehmenStammdaten.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.AnalystenPflegeTool.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.AnalystenPflegeTool.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.TermineBearbeiten.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.TermineBearbeiten.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Launcher.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\WhiteTests\\Mescor.Applications.Launcher.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Applications.Empfehlungen.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Applications.Basis.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Applications.Basis.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Applications.Basis.ExcelExporter.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Images.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.AdminTool.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Applications.AdminTool.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.ScreeningClient.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.ScreeningClient.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Applications.ResearchDataExplorer.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.ResearchDataExplorer.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\ChartProduction.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.ChartProduction.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\Mescor.Applications.Webclient\\bin\\Mescor.Applications.Webclient.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\TestX\\Mescor.Applications.Webclient.FunktionaleTests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.Webclient.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\MapMover\\Mescor.Applications.MapMover.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Applications.Waehrungskurse.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Prozesse\\SystemProzesse\\Mescor.Applications.Prozesse.SystemProzesse.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.Prozesse.SystemProzesse.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Prozesse\\RBP\\RBP.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Applications.Prozesse.RBP.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Mescor.Applications.LogBuch.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\Mescor.Applications.LogBuch.Tests\\..bin\\Debug\\Test\\Mescor.Applications.LogBuch.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\EventTrigger\\Mescor.Applications.EventTrigger.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\ServerControl\\ServerControl.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\Mescor.Server.AppServer.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.AppServer.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\Mescor.Server.AppServer.Service.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.Models.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.DAOs.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.DAOs.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.DataServer.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.DataServer.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.MemoryDao.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.DataServer.Service.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.Assembler.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.Assembler.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\NetBridgeServer\\Mescor.Server.NetBridgeServer.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\Mescor.Server.MapMover\\..bin\\Debug\\MapMover\\Mescor.Server.MapMover.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Server.MapMover.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Services.Launcher.exe",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Mescor.Server.Base.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\Persistence.Tests\\bin\\Debug\\Persistence.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.Macros.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.Macros.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.Research.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.Research.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.OfficeAddin.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.OfficeAddin.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.DataExplorer.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.DataExplorer.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.ServerControl.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.Rest.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.Rest.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Mescor.Services.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Mescor.Services.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\Mescor.Services.Recommendation.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\ServiceModel.Extension.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Persistence.Testsupport.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Service.Support.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Basis.Model.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Basis.Model.Test.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\UI.Extensions.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Applications.Models.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Applications.Services.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Applications.Services.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Applications.Models.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Applications.Charts.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\Applications.Charts.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\UI.TestSupport.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\UI.Extensions.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Lib\\Service.Logging.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\Persistence\\bin\\Debug\\Persistence.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\ResearchBrowser.FunktionaleTests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\ResearchBrowser.GuiTests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Build.First.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Server\\Build.Last.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Addins\\OfficeAddIn.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Addins\\MescorNGFunctions.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\OfficeAddInFunctions.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Addins\\OfficeAddIn.Basis.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\OfficeAddIn.Basis.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\AddinAbfrageMetzler.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\AppServer\\PlugIns\\MainFirst\\AddinAbfrageMainFirst.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\AddinAbfrageMainFirst.Test.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Test\\AddinAbfrageMetzler.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Client\\Office.DocumentGeneration.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\bin\\Debug\\Office.DocumentGeneration.Tests.dll",
                                     "D:\\e\\Mescor\\Mescor.NET\\AppConfigs\\bin\\Debug\\AppConfigs.dll"
                                 }; 
        #endregion

        [TestMethod]
        public void AnalyzeMescorLibraries()
        {
            //Console.WriteLine("Sequential");
            //OutputAnalysisTimes("Mescor", Analyze.PortableExecutables(_libraries));
            //Console.WriteLine("Parallel");
            //OutputAnalysisTimes("Mescor", AnalyzeParallel.PortableExecutables(_libraries));
        }
    }
}