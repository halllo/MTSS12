using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus.net
{
    public class SolutionAwareToolWindowPane : ToolWindowPane
    {
        public SolutionAwareToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
            PreInitializeEvents();
        }

        protected override void Initialize()
        {
            base.Initialize();
            SubscripeToEvents();
        }

        private EnvDTE80.DTE2 GetDTE2()
        {
            return base.GetService(typeof(SDTE)) as EnvDTE80.DTE2;
        }

        #region Solution & Projects
        protected EnvDTE.Solution Solution
        {
            get
            {
                return GetDTE2().Solution;
            }
        }

        protected IEnumerable<EnvDTE.Project> Projects
        {
            get
            {
                foreach (var project in Solution.Projects)
                {
                    yield return project as EnvDTE.Project;
                }
            }
        } 
        #endregion

        #region Events
        public event Action SolutionChanged;
        public event Action SavingDone;
        public event Action CommandDone;
        public event Action BuildStart;
        public event Action<bool> BuildDone;

        private void PreInitializeEvents()
        {
            SolutionChanged += () => { };
            SavingDone += () => { };
            CommandDone += () => { };
            BuildDone += (s) => { };
            BuildStart += () => { };
        }

        private EnvDTE.BuildEvents buildEvents;
        private EnvDTE.CommandEvents commandEvents;
        private EnvDTE.DocumentEvents documentEvents;
        private EnvDTE.SolutionEvents solutionEvents;

        private void SubscripeToEvents()
        {
            var events = GetDTE2().Events;
            buildEvents = events.BuildEvents;
            commandEvents = events.CommandEvents;
            documentEvents = events.DocumentEvents;
            solutionEvents = events.SolutionEvents;

            buildEvents.OnBuildBegin += new EnvDTE._dispBuildEvents_OnBuildBeginEventHandler(BuildEvents_OnBuildBegin);
            buildEvents.OnBuildDone += new EnvDTE._dispBuildEvents_OnBuildDoneEventHandler(BuildEvents_OnBuildDone);
            commandEvents.AfterExecute += new EnvDTE._dispCommandEvents_AfterExecuteEventHandler(CommandEvents_AfterExecute);
            documentEvents.DocumentSaved += new EnvDTE._dispDocumentEvents_DocumentSavedEventHandler(DocumentEvents_DocumentSaved);
            solutionEvents.Opened += new EnvDTE._dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);
            solutionEvents.ProjectAdded += new EnvDTE._dispSolutionEvents_ProjectAddedEventHandler(SolutionEvents_ProjectAdded);
            solutionEvents.ProjectRemoved += new EnvDTE._dispSolutionEvents_ProjectRemovedEventHandler(SolutionEvents_ProjectRemoved);
            solutionEvents.ProjectRenamed += new EnvDTE._dispSolutionEvents_ProjectRenamedEventHandler(SolutionEvents_ProjectRenamed);
            solutionEvents.Renamed += new EnvDTE._dispSolutionEvents_RenamedEventHandler(SolutionEvents_Renamed);
            solutionEvents.AfterClosing += new EnvDTE._dispSolutionEvents_AfterClosingEventHandler(SolutionEvents_AfterClosing);
        }

        void SolutionEvents_AfterClosing()
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
            BuildDone(Solution.SolutionBuild.LastBuildInfo == 0);
        }

        void BuildEvents_OnBuildBegin(EnvDTE.vsBuildScope Scope, EnvDTE.vsBuildAction Action)
        {
            BuildStart();
        }
        #endregion
    }
}
