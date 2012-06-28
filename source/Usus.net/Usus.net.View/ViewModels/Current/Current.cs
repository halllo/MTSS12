using System;

namespace andrena.Usus.net.View.ViewModels.Current
{
    public class Current : AnalysisAwareViewModel
    {
        public Current()
        {

        }

        protected override void AnalysisStarted()
        {
            throw new NotImplementedException();
        }

        protected override void AnalysisFinished(Core.Reports.MetricsReport metrics)
        {
            throw new NotImplementedException();
        }
    }
}
