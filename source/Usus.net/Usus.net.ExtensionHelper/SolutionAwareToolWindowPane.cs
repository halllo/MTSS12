using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.ExtensionHelper
{
    public class SolutionAwareToolWindowPane : DtAwareToolWindow
    {
        public SolutionAwareToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
        }

        protected EnvDTE.Solution RawSolution { get { return MasterObjekt.Solution; } }
        protected IEnumerable<EnvDTE.Project> RawProjects { get { return RawSolution.Projects.Cast<EnvDTE.Project>(); } }

        protected IEnumerable<Project> Projects
        {
            get
            {
                return from project in RawProjects
                       where project.Properties != null
                       select new Project(project);
            }
        }
    }
}
