using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace Usus.net.UI.Controls.ViewModel
{
    public class SolutionView
    {
        public ObservableCollection<Project> Projects { get; private set; }
        public ObservableCollection<Event> Events { get; private set; }
        public ObservableCollection<Method> Methods { get; private set; }

        public SolutionView()
        {
            Projects = new ObservableCollection<Project>();
            Events = new ObservableCollection<Event>();
            Methods = new ObservableCollection<Method>();
        }

        public void SetProjects(IEnumerable<Project> projects)
        {
            Projects.Clear();
            foreach (var project in projects) Projects.Add(project);
        }

        public void SetEvent(Event vsEvent)
        {
            Events.Add(vsEvent);
            if (vsEvent.Type == "build") Analyze();
        }

        readonly string outputDirectory = @"D:\e\fxcop\";
        private void Analyze()
        {
            ClearOutputDirectory();
            CreateAnalysationFiles();
            System.Threading.Thread.Sleep(2000);//waiting for the files to appear on disk
            ImportAnalysationFiles();
        }

        private void ImportAnalysationFiles()
        {
            Methods.Clear();
            foreach (var file in Directory.GetFiles(outputDirectory))
            {
                var lines = File.ReadAllLines(file);
                foreach (var line in lines)
                {
                    var mn = line.Substring(0, line.IndexOf("->")).Trim();
                    var nos = int.Parse(line.Substring(line.IndexOf("->") + 2, line.IndexOf("statements, ") - line.IndexOf("->") - 2).Trim());
                    var cc = int.Parse(line.Substring(line.IndexOf(",") + 1, line.IndexOf("cc, ") - line.IndexOf(",") - 1).Trim());
                    var cls = line.Substring(line.IndexOf("{"), line.IndexOf("}") - line.IndexOf("{") + 1);
                    Methods.Add(new Method { Name = mn, Statements = nos, CyclomaticComplexity = cc, Callees = cls });
                }
            }
        }

        private void CreateAnalysationFiles()
        {
            var ususRule = new TechEval_FxCop.UsusRuleIntrospection();
            foreach (var project in Projects)
            {
                string fileToAnalyze = project.OutputFile().FullName;
                ususRule.Introspect(fileToAnalyze);
            }
        }

        private void ClearOutputDirectory()
        {
            foreach (var file in Directory.GetFiles(outputDirectory))
            {
                File.Delete(file);
            }
        }
    }
}
