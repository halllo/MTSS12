using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Usus.net.UI.Controls.ViewModel
{
    public class Project
    {
        public string Name { get; set; }
        public string ProjectPath { get; set; }
        public string ProjectFile { get; set; }
        public string OutputAssembly { get; set; }

        public FileInfo OutputFile()
        {
            var files = Directory.EnumerateFiles(ProjectPath, OutputAssembly, SearchOption.AllDirectories);
            return new FileInfo(files.FirstOrDefault());
        }
    }
}
