using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace andrena.Usus.net.ExtensionHelper
{
    public class Project
    {
        public string Name { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectFile { get; set; }
        public string OutputAssembly { get; set; }

        internal static bool IsValid(EnvDTE.Project project)
        {
            return project.Properties != null 
                && !string.IsNullOrEmpty(project.FullName);
        }

        internal Project(EnvDTE.Project project)
        {
            Name = project.Name;
            ProjectFile = project.FullName;
            OutputAssembly = project.Properties.Item("OutputFileName").Value.ToString();
            ProjectPath = project.Properties.Item("FullPath").Value.ToString();
        }

        public FileInfo LatestOutputAssembly()
        {
            return OutputAssemblies().WithMax(a => a.LastWriteTime);
        }

        public IEnumerable<FileInfo> OutputAssemblies()
        {
            return from file in AllOutputAssemblies()
                   select new FileInfo(file);
        }

        private IEnumerable<string> AllOutputAssemblies()
        {
            return Directory.EnumerateFiles(ProjectPath + "bin", OutputAssembly, SearchOption.AllDirectories);
        }
    }
}
