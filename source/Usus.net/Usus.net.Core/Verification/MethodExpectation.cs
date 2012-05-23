using System;
using andrena.Usus.net.Core.Metrics;

namespace andrena.Usus.net.Core.Verification
{
    public abstract class MethodExpectation : Attribute
    {
        public abstract bool Verify(MethodMetricsReport metrics);
        public abstract string Expectation { get; }

        public object Message
        {
            get { return String.Format("\"{0}\" [{1}]", Expectation, ToString()); }
        }
    }
}
