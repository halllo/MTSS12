using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
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

        public event Action<PreparedMetricsReport> MetricsReady;
        public event Action AnalysisStarted;

        public PreparedMetricsReport MostRecentMetrics { get; private set; }

        private ViewHub()
        {
            AnalysisStarted += () => analysisReady = false;
            MetricsReady += m => analysisReady = true;
            MetricsReady += m => MostRecentMetrics = m;
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
                var metrics = AnalyzeProjectFilesOrNotifyError(files);
                MetricsReady(metrics);
            });
        }

        private PreparedMetricsReport AnalyzeProjectFilesOrNotifyError(IEnumerable<string> files)
        {
            return files.Any() ? AnalyzeProjectFiles(files) : NotifyError();
        }

        private PreparedMetricsReport AnalyzeProjectFiles(IEnumerable<string> files)
        {
            MetricsReport metrics = Analyze.PortableExecutable(files.ToArray());
            return new PreparedMetricsReport(metrics);
        }

        private PreparedMetricsReport NotifyError()
        {
            MessageBox.Show("No projects found in current solution.", "No projects", MessageBoxButton.OK, MessageBoxImage.Information);
            return null;
        }
    }
}
