using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace BuildSaveUi
{
    public class BuildSaveViewModel
    {
        public ICommand SendBackCommand { get; set; }
        public ObservableCollection<EventViewModel> Events { get; set; }

        public BuildSaveViewModel()
        {
            Events = new ObservableCollection<EventViewModel>();
            SendBackCommand = new ActionCommand(SendBack);
        }

        public void BuildStart()
        {
            AddEvent("build start");
        }

        public void BuildEnd(bool success)
        {
            AddEvent(String.Format("build end: {0}successful", (success ? "" : "not ")));
        }

        public void Save()
        {
            AddEvent("save");
        }

        private void AddEvent(string buildText)
        {
            Events.Add(new EventViewModel { Time = DateTime.Now.ToString(), Text = buildText });
        }

        private void SendBack()
        {
            MessageBox.Show("not yet functional!", "send back");
        }
    }
}
