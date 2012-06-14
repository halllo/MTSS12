using System.Collections.Generic;
using System;

namespace andrena.Usus.net.Core.Reports
{
    public class NamespaceMetricsReport
    {
        public string Name { get; internal set; }
        public int CyclicDependencies { get; internal set; }

        internal NamespaceMetricsReport()
        { }
    }
}
