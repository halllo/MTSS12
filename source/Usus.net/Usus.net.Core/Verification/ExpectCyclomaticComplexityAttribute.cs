using System;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExpectCyclomaticComplexityAttribute : MethodExpectation
    {
        public int ExpectedCyclomaticComplexity { get; private set; }

        public ExpectCyclomaticComplexityAttribute(int value)
        {
            ExpectedCyclomaticComplexity = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.CyclomaticComplexity == ExpectedCyclomaticComplexity;
        }

        public override string Expectation
        {
            get { return ExpectedCyclomaticComplexity.ToString(); }
        }
    }
}
