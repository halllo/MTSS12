
namespace andrena.Usus.net.Core.Reports
{
    public class CommonReportKnowledge
    {
        public int NumberOfMethods { get; private set; }
        public int NumberOfTypes { get; private set; }
        public int NumberOfNamespaces { get; private set; }
        public int RelevantLinesOfCode { get; private set; }

        internal CommonReportKnowledge()
        { }

        internal CommonReportKnowledge(int methods, int classes, int namespaces, int rlocs)
        {
            NumberOfMethods = methods;
            NumberOfTypes = classes;
            NumberOfNamespaces = namespaces;
            RelevantLinesOfCode = rlocs;
        }

        internal void UpdateFor(MethodMetricsReport method)
        {
            if (!method.CompilerGenerated)
            {
                NumberOfMethods++;
                RelevantLinesOfCode += LinesOfMethodDefintion(method);
            }
        }

        private static int LinesOfMethodDefintion(MethodMetricsReport method)
        {
            return 1 + method.MethodLength;
        }

        internal void UpdateFor(TypeMetricsReport type)
        {
            if (!type.CompilerGenerated)
            {
                NumberOfTypes++;
                RelevantLinesOfCode += 2 + type.NumberOfFields;
            }
        }

        internal void UpdateFor(NamespaceMetricsWithTypeMetrics namespaceMertics)
        {
            NumberOfNamespaces++;
        }
    }
}
