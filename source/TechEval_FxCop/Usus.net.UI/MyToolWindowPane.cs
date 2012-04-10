using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;

namespace andrena.Usus_net_UI
{
    public class MyToolWindowPane : ToolWindowPane
    {
        public MyPackage MyPack { get; set; }

        public MyToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
        }

        protected IEnumerable<EnvDTE.Project> GetProjects()
        {
            foreach (var project in MyPack.GetSolution().Projects)
            {
                yield return project as EnvDTE.Project;
            }
        }
    }
}
