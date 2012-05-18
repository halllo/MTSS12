using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Cci;
using andrena.Usus.net.Core.AssemblyNavigation;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    public abstract class MetricGathering
    {
        public void Analyze(string assemblyPath)
        {
            using (var host = new PeReader.DefaultHost())
                AnalyzeInHost(assemblyPath, host);
        }

        private void AnalyzeInHost(string toAnalyse, IMetadataHost host)
        {
            var assembly = host.LoadUnitFrom(toAnalyse) as IAssembly;
            string pdbPath = GetProgramDatabasePath(toAnalyse);
            AnalyzeAssemblyInHost(host, assembly, pdbPath);
        }

        private string GetProgramDatabasePath(string toAnalyse)
        {
            string pdbFile = Path.ChangeExtension(toAnalyse, "pdb");
            return File.Exists(pdbFile) ? pdbFile : null;
        }

        private void AnalyzeAssemblyInHost(IMetadataHost host, IAssembly assembly, string pdbPath)
        {
            if (pdbPath != null)
                AnalyzeAssemblyInHostWithProgramDatabase(assembly, host, pdbPath);
            else
                AnalyzeTypes(assembly, null);
        }

        private void AnalyzeAssemblyInHostWithProgramDatabase(IAssembly assembly, IMetadataHost host, string pdbPath)
        {
            using (var pdb = GetProgramDatabase(host, pdbPath))
                AnalyzeTypes(assembly, pdb);
        }

        private PdbReader GetProgramDatabase(IMetadataHost host, string pdbPath)
        {
            return new PdbReader(File.OpenRead(pdbPath), host);
        }

        private void AnalyzeTypes(IAssembly assembly, PdbReader pdb)
        {
            foreach (var type in assembly.GetTypesNotGenerated())
            {
                AnalyzeType(type, pdb);
                AnalyzeMethods(type, pdb);
            }
        }

        private void AnalyzeMethods(INamedTypeDefinition type, PdbReader pdb)
        {
            foreach (var method in type.GetMethodsNotGenerated())
            {
                AnalyzeMethod(method, pdb);
            }
        }

        protected abstract void AnalyzeType(INamedTypeDefinition type, PdbReader pdb);
        protected abstract void AnalyzeMethod(IMethodDefinition method, PdbReader pdb);
    }
}
