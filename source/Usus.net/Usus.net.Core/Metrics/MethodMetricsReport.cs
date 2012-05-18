using System;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Metrics
{
    public class MethodMetricsReport
    {
        public string MethodName { get; set; }
        public int CyclomaticComplexity { get; set; }
        public int MethodLength { get; set; }
        public int MethodLengthWithSymbols { get; set; }
        public IEnumerable<string> TypeDependencies { get; set; }
    }
}
