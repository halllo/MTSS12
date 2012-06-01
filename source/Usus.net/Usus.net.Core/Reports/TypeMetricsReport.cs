using System.Collections.Generic;

namespace andrena.Usus.net.Core.Reports
{
    public class TypeMetricsReport
    {
        public string Name { get; internal set; }
        public bool CompilerGenerated { get; internal set; }

        public int NumberOfNonStaticPublicFields { get; internal set; }

        internal TypeMetricsReport()
        {
        }
    }
}
