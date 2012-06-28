using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using andrena.Usus.net.Core;
using andrena.Usus.net.Core.Reports;

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

        public MetricsReport MostRecentMetrics { get; private set; }

        private ViewHub()
        {
            AnalysisStarted += () => analysisReady = false;
            MetricsReady += (m) => analysisReady = true;
            MetricsReady += (m) => MostRecentMetrics = m;
        }

        bool analysisReady = true;
        public void TryStartAnalysis(IEnumerable<string> files)
        {
            if (analysisReady) StartAnalysis(files);
        }

        private void StartAnalysis(IEnumerable<string> files)
        {
            AnalysisStarted();
            ThreadPool.QueueUserWorkItem((c) =>
            {
                MetricsReport metrics = Analyze.PortableExecutable(files.ToArray());
                MetricsReady(metrics);
            });
        }
    }
}
