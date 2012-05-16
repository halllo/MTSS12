using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core
{
    public class UsusEngine
    {
        public static void Analyze(string assemblyPath)
        {
            using (var host = new PeReader.DefaultHost())
                AnalyzeInHost(assemblyPath, host);
        }

        private static void AnalyzeInHost(string toAnalyse, IMetadataHost host)
        {
            var assembly = host.LoadUnitFrom(toAnalyse) as IAssembly;
            string pdbPath = GetProgramDatabasePath(toAnalyse);
            AnalyzeAssemblyInHost(host, assembly, pdbPath);
        }

        private static string GetProgramDatabasePath(string toAnalyse)
        {
            string pdbFile = Path.ChangeExtension(toAnalyse, "pdb");
            return File.Exists(pdbFile) ? pdbFile : null;
        }

        private static void AnalyzeAssemblyInHost(IMetadataHost host, IAssembly assembly, string pdbPath)
        {
            if (pdbPath != null)
                AnalyzeAssemblyInHostWithProgramDatabase(assembly, host, pdbPath);
            else
                AnalyzeAssembly(assembly, null);
        }
        private static void AnalyzeAssemblyInHostWithProgramDatabase(IAssembly assembly, IMetadataHost host, string pdbPath)
        {
            using (var pdb = GetProgramDatabase(host, pdbPath))
                AnalyzeAssembly(assembly, pdb);
        }

        private static PdbReader GetProgramDatabase(IMetadataHost host, string pdbPath)
        {
            return new PdbReader(File.OpenRead(pdbPath), host);
        }

        private static void AnalyzeAssembly(IAssembly assembly, PdbReader pdb)
        {
            foreach (var type in assembly.GetTypesNotGenerated())
                type.Analyze(pdb);
        }
    }
}
