using System;
using System.Linq;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Verification
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ExpectTypeDependencyAttribute : MethodExpectation
    {
        public string ExpectedTypeDependency { get; private set; }

        public ExpectTypeDependencyAttribute(string value)
        {
            ExpectedTypeDependency = value;
        }

        public override bool Verify(MethodMetricsReport metrics)
        {
            return metrics.TypeDependencies.Contains(ExpectedTypeDependency);
        }

        public override string Expectation
        {
            get { return ExpectedTypeDependency; }
        }
    }
}
