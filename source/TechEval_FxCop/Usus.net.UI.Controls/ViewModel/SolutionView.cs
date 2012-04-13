using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using Usus.net.UI.Controls.Model;

namespace Usus.net.UI.Controls.ViewModel
{
    public class SolutionView
    {
        readonly UsusFxCopRuleEngine ususEngine = new UsusFxCopRuleEngine();

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
            if (vsEvent.Type == Event.Of.build) AnalyzeMethods();
        }

        private void AnalyzeMethods()
        {
            Methods.Clear();
            foreach (var method in GetAnalyzedMethods())
                Methods.Add(method);
        }

        private IEnumerable<Method> GetAnalyzedMethods()
        {
            return ususEngine.Analyze(from p in Projects select p.OutputFile().FullName);
        }
    }
}
