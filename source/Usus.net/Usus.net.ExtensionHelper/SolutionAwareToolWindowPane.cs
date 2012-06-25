using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus.net.ExtensionHelper
{
    public class SolutionAwareToolWindowPane : ToolWindowPane
    {
        public SolutionAwareToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
        }

        protected EnvDTE80.DTE2 GetDTE2()
        {
            return base.GetService(typeof(SDTE)) as EnvDTE80.DTE2;
        }

        protected EnvDTE.Solution RawSolution { get { return GetDTE2().Solution; } }

        protected IEnumerable<EnvDTE.Project> RawProjects { get { return RawSolution.Projects.Cast<EnvDTE.Project>(); } }

        protected IEnumerable<Project> Projects { get { return from project in RawProjects select new Project(project); } }
    }
}
