using System;
using andrena.Usus.net.Core.Reports;
using System.Threading;
using System.Collections.Generic;

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

        public void StartAnalysis(IEnumerable<string> files)
        {
            AnalysisStarted();
            throw new NotImplementedException("continue adding support for multiple files here!");
            ThreadPool.QueueUserWorkItem((c) =>
            {
                //MetricsReport metrics = Core.Analyze.PortableExecutable(files);
                //MetricsReady(metrics);
            });
        }
    }
}
