using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.SQI
{
    public static class Calculate
    {
        public static double SoftwareQualityIndex(this IParameterProvider parameters)
        {
            return parameters.CalculateAllSqiMetrics().Sum();
        }

        private static IEnumerable<double> CalculateAllSqiMetrics(this IParameterProvider parameters)
        {
            yield return CalculateTestCoverage(parameters);
            yield return CalculateNamespacesInCycles(parameters);
            yield return CalculateCompilcatedMethods(parameters);
            yield return CalculateAcd(parameters);
            yield return CalculateBigClasses(parameters);
            yield return CalculateBigMethods(parameters);
            yield return CalculateCompilerWarnings(parameters);
        }

        private static double CalculateCompilerWarnings(IParameterProvider parameters)
        {
            return 0.36 * parameters.SqNiveau(m => m.CompilerWarnings, Sqi.RelativeCompilerWarnings, Sqi.CalibrationCompilerWarnings);
        }
        private static double CalculateBigMethods(IParameterProvider parameters)
        {
            return 1.05 * parameters.SqNiveau(m => m.BigMethods, Sqi.RelativeSizeBigMethods, Sqi.CalibrationBigMethods) 
                * parameters.SqNiveauCorrection(m => m.BigMethods, Sqi.MiddleSizeBigMethods, Sqi.CorrectionBigMethods);
        }
        private static double CalculateBigClasses(IParameterProvider parameters)
        {
            return 1.05 * parameters.SqNiveau(m => m.BigClasses, Sqi.RelativeSizeBigClasses, Sqi.CalibrationBigClasses) 
                * parameters.SqNiveauCorrection(m => m.BigClasses, Sqi.MiddleSizeBigClasses, Sqi.CorrectionBigClasses);
        }
        private static double CalculateAcd(IParameterProvider parameters)
        {
            return 1.58 * parameters.SqNiveau(m => m.AverageComponentDependency, Sqi.RelativeSizeAcd, Sqi.CalibrationAcd) 
                * parameters.SqNiveauCorrection(m => m.AverageComponentDependency, Sqi.MiddleSizeAcd, Sqi.CorrectionAcd);
        }
        private static double CalculateCompilcatedMethods(IParameterProvider parameters)
        {
            return 1.75 * parameters.SqNiveau(m => m.ComplicatedMethods, Sqi.RelativeSizeComplicatedMethods, Sqi.CalibrationComplicatedMethods) 
                * parameters.SqNiveauCorrection(m => m.ComplicatedMethods, Sqi.MiddleSizeComplicatedMethods, Sqi.CorrectionComplicatedMethods);
        }
        private static double CalculateNamespacesInCycles(IParameterProvider parameters)
        {
            return 1.93 * parameters.SqNiveau(m => m.NamespaceCycles, Sqi.RelativeSizeNamespacesInCycles, Sqi.CalibrationNamespacesInCycles) 
                * parameters.SqNiveauCorrection(m => m.NamespaceCycles, Sqi.MiddleSizeNamespacesInCycles, Sqi.CorrectionNamespacesInCycles);
        }
        private static double CalculateTestCoverage(IParameterProvider parameters)
        {
            return 2.28 * parameters.TestCoverage;
        }
    }
}
