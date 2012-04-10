using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus_net_UI
{
    public class MyPackage : Package
    {
        public event Action SolutionChanged;
        public event Action SavingDone;
        public event Action CommandDone;
        public event Action BuildDone;

        public MyPackage()
        {
            SolutionChanged += () => { };
            SavingDone += () => { };
            CommandDone += () => { };
            BuildDone += () => { };
        }

        public EnvDTE.Solution GetSolution()
        {
            return GetDTE2().Solution;
        }

        private EnvDTE80.DTE2 GetDTE2()
        {
            return base.GetService(typeof(SDTE)) as EnvDTE80.DTE2;
        }

        public void SubscripeToEvents()
        {
            var events = GetDTE2().Events;
            events.BuildEvents.OnBuildDone += new EnvDTE._dispBuildEvents_OnBuildDoneEventHandler(BuildEvents_OnBuildDone);
            events.CommandEvents.AfterExecute += new EnvDTE._dispCommandEvents_AfterExecuteEventHandler(CommandEvents_AfterExecute);
            events.DocumentEvents.DocumentSaved += new EnvDTE._dispDocumentEvents_DocumentSavedEventHandler(DocumentEvents_DocumentSaved);
            events.SolutionEvents.Opened += new EnvDTE._dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);
            events.SolutionEvents.ProjectAdded += new EnvDTE._dispSolutionEvents_ProjectAddedEventHandler(SolutionEvents_ProjectAdded);
            events.SolutionEvents.ProjectRemoved += new EnvDTE._dispSolutionEvents_ProjectRemovedEventHandler(SolutionEvents_ProjectRemoved);
            events.SolutionEvents.ProjectRenamed += new EnvDTE._dispSolutionEvents_ProjectRenamedEventHandler(SolutionEvents_ProjectRenamed);
            events.SolutionEvents.Renamed += new EnvDTE._dispSolutionEvents_RenamedEventHandler(SolutionEvents_Renamed);
            events.SolutionEvents.QueryCloseSolution += new EnvDTE._dispSolutionEvents_QueryCloseSolutionEventHandler(SolutionEvents_QueryCloseSolution);
        }

        void SolutionEvents_QueryCloseSolution(ref bool fCancel)
        {
            SolutionChanged();
        }

        void SolutionEvents_Renamed(string OldName)
        {
            SolutionChanged();
        }

        void SolutionEvents_ProjectRenamed(EnvDTE.Project Project, string OldName)
        {
            SolutionChanged();
        }

        void SolutionEvents_ProjectRemoved(EnvDTE.Project Project)
        {
            SolutionChanged();
        }

        void SolutionEvents_ProjectAdded(EnvDTE.Project Project)
        {
            SolutionChanged();
        }

        void SolutionEvents_Opened()
        {
            SolutionChanged();
        }

        void DocumentEvents_DocumentSaved(EnvDTE.Document Document)
        {
            SavingDone();
        }

        void CommandEvents_AfterExecute(string Guid, int ID, object CustomIn, object CustomOut)
        {
            CommandDone();
        }

        void BuildEvents_OnBuildDone(EnvDTE.vsBuildScope Scope, EnvDTE.vsBuildAction Action)
        {
            BuildDone();
        }
    }
}
