using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class MethodMetricsReport
    {
        public string Name { get; internal set; }
        public string Signature { get; internal set; }
        public bool CompilerGenerated { get; internal set; }

        public int CyclomaticComplexity { get; internal set; }
        public int NumberOfStatements { get; internal set; }
        public int NumberOfRealLines { get; internal set; }
        public int NumberOfLogicalLines { get; internal set; }
        public IEnumerable<string> TypeDependencies { get; internal set; }

        public int MethodLength
        {
            get
            {
                return NumberOfLogicalLines < 0 ? NumberOfStatements : NumberOfLogicalLines;
            }
        }

        internal MethodMetricsReport()
        {
        }
    }
}
