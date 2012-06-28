using System.Windows.Media;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels
{
    public abstract class AnalysisAwareViewModel : ViewModel, IHubConnect
    {
        public SolidColorBrush ReadyColor { get; protected set; }
        public SolidColorBrush NotReadyColor { get; protected set; }

        public SolidColorBrush StatusColor { get; private set; }

        public AnalysisAwareViewModel()
        {
            ReadyColor = new SolidColorBrush(Colors.DarkGreen);
            NotReadyColor = new SolidColorBrush(Colors.LightGray);
            StatusColor = ReadyColor;
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
                StatusColor = NotReadyColor;
                Changed(() => StatusColor);
            });
            AnalysisStarted();
        }

        private void OnAnalysisFinished(MetricsReport m)
        {
            AnalysisFinished(m);
            Dispatch(() =>
            {
                StatusColor = ReadyColor;
                Changed(() => StatusColor);
            });
        }

        protected abstract void AnalysisStarted();

        protected abstract void AnalysisFinished(MetricsReport metrics);
    }
}
