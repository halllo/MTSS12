using System;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExpectNumberOfRealLinesAttribute : MethodExpectation
    {
        public int ExpectedNumberOfRealLines { get; private set; }

        public ExpectNumberOfRealLinesAttribute(int value)
        {
            ExpectedNumberOfRealLines = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.NumberOfRealLines == ExpectedNumberOfRealLines;
        }

        public override string Expectation
        {
            get { return ExpectedNumberOfRealLines.ToString(); }
        }
    }
}
