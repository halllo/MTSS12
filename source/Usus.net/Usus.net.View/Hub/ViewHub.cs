using System;
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

        private ViewHub()
        {
            MetricsReady += (m) => { };
        }

        public void StartAnalysis(string path)
        {
            MetricsReady(Core.Analyze.PortableExecutable(path));
        }
    }
}
