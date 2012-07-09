using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels
{
    public abstract class AnalysisAwareViewModel : ViewModel
    {
        public bool AnalysisRunning { get; private set; }

        public AnalysisAwareViewModel()
        {
            AnalysisRunning = false;
        }

        public void RegisterHub(ViewHub hub)
        {
            hub.AnalysisStarted += () => OnAnalysisStarted();
            hub.MetricsReady += m => OnAnalysisFinished(m);
            if (hub.MostRecentMetrics != null)
                OnAnalysisFinished(hub.MostRecentMetrics);
        }

        private void OnAnalysisStarted()
        {
            Dispatch(() =>
            {
                AnalysisRunning = true;
                Changed(() => AnalysisRunning);
            });
            AnalysisStarted();
        }

        private void OnAnalysisFinished(MetricsReport m)
        {
            AnalysisFinished(m);
            Dispatch(() =>
            {
                AnalysisRunning = false;
                Changed(() => AnalysisRunning);
            });
        }

        protected abstract void AnalysisStarted();

        protected abstract void AnalysisFinished(MetricsReport metrics);
    }
}
