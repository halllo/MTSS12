using System;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExpectNumberOfLogicalLinesAttribute : MethodExpectation
    {
        public int ExpectedNumberOfLogicalLines { get; private set; }

        public ExpectNumberOfLogicalLinesAttribute(int value)
        {
            ExpectedNumberOfLogicalLines = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.NumberOfLogicalLines == ExpectedNumberOfLogicalLines;
        }

        public override string Expectation
        {
            get { return ExpectedNumberOfLogicalLines.ToString(); }
        }
    }
}
