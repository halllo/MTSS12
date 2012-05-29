using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
    public class MethodMetricsReport
    {
        public string Name { get; set; }
        public string Signature { get; set; }
        public bool CompilerGenerated { get; set; }

        public int CyclomaticComplexity { get; set; }
        public int NumberOfStatements { get; set; }
        public int NumberOfRealLines { get; set; }
        public int NumberOfLogicalLines { get; set; }
        public IEnumerable<string> TypeDependencies { get; set; }
    }
}
