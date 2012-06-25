using System;
using System.Collections.Generic;

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
            throw new NotImplementedException("continue adding support for multiple files here!");
            yield return "";
        }
    }
}
