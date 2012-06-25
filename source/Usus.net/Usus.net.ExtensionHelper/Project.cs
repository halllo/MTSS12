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

        internal Project(EnvDTE.Project project)
        {
            Name = project.Name;
            OutputAssembly = project.Properties.Item("OutputFileName").Value.ToString();
            ProjectPath = project.Properties.Item("FullPath").Value.ToString();
            ProjectFile = project.FullName;
        }

        public FileInfo OutputFile()
        {
            var files = Directory.EnumerateFiles(ProjectPath, OutputAssembly, SearchOption.AllDirectories);
            return new FileInfo(files.FirstOrDefault());
        }
    }
}
