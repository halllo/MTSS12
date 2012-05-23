using System.Linq;
using System.Reflection;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Metrics;
using andrena.Usus.net.Core.ReflectionHelper;
using System;

namespace andrena.Usus.net.Core.Verification
{
    public static class Verify
    {
        public static void AnalyzeMe(this MetricGathering metrics)
        {
            metrics.Analyze(Assembly.GetCallingAssembly());
        }

        public static void Analyze(this MetricGathering metrics, Assembly asm)
        {
            metrics.Analyze(asm.Location);
        }

        public static bool MethodsWith<T>(MetricsReport metrics) where T : MethodExpectation
        {
            var methods = Assembly.GetCallingAssembly().GetMethodsWithAssigned<T>();
            return methods.All(m => VerifyMethod<T>(m, metrics));
        }

        private static bool VerifyMethod<T>(AttributeExtensions.MethodWithAttributes<T> method, MetricsReport metrics) where T : MethodExpectation
        {
            return method.Attributes.All(a => VerifyExpectation<T>(a, method.Method, metrics));
        }

        private static bool VerifyExpectation<T>(T expectation, MethodInfo method, MetricsReport metrics) where T : MethodExpectation
        {
            bool verified = expectation.Verify(metrics.For(method));
            if (!verified) throw new VerificationException(method, expectation);
            return verified;
        }
    }
}
