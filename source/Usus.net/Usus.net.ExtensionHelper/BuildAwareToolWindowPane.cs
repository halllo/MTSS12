using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE80;

namespace andrena.Usus.net.ExtensionHelper
{
    public class BuildAwareToolWindowPane : SolutionEventsAwareToolWindowPane
    {
        public event Action<IEnumerable<string>> BuildSuccessfull;

        public BuildAwareToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
            BuildSuccessfull += fs => { };
            BuildDone += OnBuildDone;
        }

        private void OnBuildDone(bool success)
        {
            if (success) BuildSuccessfull(FindCreatedFiles());
        }

        private IEnumerable<string> FindCreatedFiles()
        {
            return from p in Projects
                   where p.HasLatestOutputAssembly
                   select p.LatestOutputAssembly().FullName;
        }

        protected CompilerErrors GetErrors()
        {
            ErrorList list = MasterObjekt.ToolWindows.ErrorList;
            CompilerErrors errors = new CompilerErrors();
            for (long index = 1; index <= list.ErrorItems.Count; index++)
            {
                AddUpErrors(errors, list.ErrorItems.Item(index));
            }
            return errors;
        }

        private void AddUpErrors(CompilerErrors errors, ErrorItem item)
        {
            switch (item.ErrorLevel)
            {
                case vsBuildErrorLevel.vsBuildErrorLevelHigh:
                    errors.ErrorCount++; break;
                case vsBuildErrorLevel.vsBuildErrorLevelMedium:
                case vsBuildErrorLevel.vsBuildErrorLevelLow:
                    errors.WarningCount++; break;
                default: break;
            }
        }
    }
}
