using System;
using andrena.Usus.net.Core.Reports;
using System.Threading;

namespace andrena.Usus.net.View.Hub
{
    public class ViewHub
    {
        static ViewHub instance;
        public static ViewHub Instance
        {
            get
            {
                if (instance == null) instance = new ViewHub();
                return instance;
            }
        }

        public event Action<MetricsReport> MetricsReady;
        public event Action AnalysisStarted;

        private ViewHub()
        {
            MetricsReady += (m) => { };
        }

        public void StartAnalysis(string path)
        {
            AnalysisStarted();
            ThreadPool.QueueUserWorkItem((c) =>
            {
                MetricsReport metrics = Core.Analyze.PortableExecutable(path);
                MetricsReady(metrics);
            });
        }
    }
}
