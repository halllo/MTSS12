using System.Diagnostics;
using System.Linq;
using System.Reflection;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.Core.ReflectionHelper;

namespace andrena.Usus.net.Core.Verification
{
    public static class Verify
    {
        public static void AnalyzeMe(this AssemblyVisitor metrics)
        {
            metrics.Analyze(Assembly.GetCallingAssembly());
        }

        public static void Analyze(this AssemblyVisitor metrics, Assembly asm)
        {
            metrics.Analyze(asm.Location);
        }

        public static bool MethodsWith<T>(MetricsReport metrics) where T : MethodExpectation
        {
            var methods = Assembly.GetCallingAssembly().GetMethodsWithAssigned<T>();
            return methods.All(m => m.VerifyMetrics<T>(metrics));
        }

        private static bool VerifyMetrics<T>(this AttributeExtensions.MethodWithAttributes<T> method, MetricsReport metrics) where T : MethodExpectation
        {
            return method.Attributes.All(a => a.VerifyMethod<T>(method.Method, metrics));
        }

        private static bool VerifyMethod<T>(this T expectation, MethodInfo method, MetricsReport metrics) where T : MethodExpectation
        {
            Debug.WriteLine("verify " + method.Name);
            var methodMetrics = metrics.GetMethodMetrics(method);
            if (expectation.Verify(methodMetrics)) return true;
            throw new VerificationException(method, expectation);
        }

        private static MethodMetricsReport GetMethodMetrics(this MetricsReport metrics, MethodInfo method)
        {
            var methodMetrics = metrics.For(method);
            if (methodMetrics != null) return methodMetrics;
            throw new MetricsNotFoundException(method);
        }
    }
}
