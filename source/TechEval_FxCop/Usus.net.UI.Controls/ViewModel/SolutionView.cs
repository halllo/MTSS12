using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Usus.net.UI.Controls.ViewModel
{
    public class SolutionView
    {
        public ObservableCollection<Project> Projects { get; private set; }
        public ObservableCollection<Event> Events { get; private set; }

        public SolutionView()
        {
            Projects = new ObservableCollection<Project>();
            Events = new ObservableCollection<Event>();
        }

        public void SetProjects(IEnumerable<Project> projects)
        {
            Projects.Clear();
            foreach (var project in projects) Projects.Add(project);
        }

        public void SetEvent(Event vsEvent)
        {
            Events.Add(vsEvent);
        }
    }
}
