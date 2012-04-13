using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;
using System.IO;

namespace UsusNetRule
{
    public class MetricsRule : BaseIntrospectionRule
    {
        Dictionary<string, Tuple<int, int, List<string>>> methodInfos;
        Dictionary<string, Tuple<int, List<string>>> classInfos;

        public MetricsRule()
            : base("MetricsRule", "UsusNetRule.UsusNetRule", typeof(MetricsRule).Assembly)
        {
            methodInfos = new Dictionary<string, Tuple<int, int, List<string>>>();
            classInfos = new Dictionary<string, Tuple<int, List<string>>>();
        }

        public override TargetVisibilities TargetVisibility
        {
            get { return TargetVisibilities.All; }
        }

        public override void BeforeAnalysis()
        {
            base.BeforeAnalysis();
        }

        public override void AfterAnalysis()
        {
            string outputDirectory = @"D:\e\fxcop\";
            CreateOutputDirectory(outputDirectory);
            CreateOutputFile(outputDirectory + DateTime.Now.Ticks + ".txt");
            base.AfterAnalysis();
        }

        #region File output
        private static void CreateOutputDirectory(string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
        }

        private void CreateOutputFile(string newFileName)
        {
            using (var fileStream = new StreamWriter(File.Create(newFileName)))
            {
                foreach (var line in GetLinesFrom(methodInfos))
                {
                    fileStream.WriteLine(line);
                }
            }
        }

        private IEnumerable<string> GetLinesFrom(IEnumerable<KeyValuePair<string, Tuple<int, int, List<string>>>> methods)
        {
            return methods.Select(m => m.Key + "\t->\t"
                + m.Value.Item1 + " statements, "
                + m.Value.Item2 + " cc, "
                + GetCalleesString(m.Value.Item3) + " callees");
        }

        private static string GetCalleesString(List<string> callees)
        {
            return "{" + string.Join(",", callees) + "}";
        }
        #endregion


        public override ProblemCollection Check(TypeNode type)
        {
            AnalyzeType(type);
            return base.Check(type);
        }

        public override ProblemCollection Check(Member member)
        {
            if (member is Method) AnalyzeMethod(member as Method);
            return base.Check(member);
        }

        private void AnalyzeMethod(Method method)
        {
            var stCount = method.NumberOfLines();
            var types = method.ReferencedTypes();
            var cc = method.CyclomaticComplexity();
            methodInfos.Add(method.FullName, Tuple.Create(stCount, cc, types.Select(t => t.FullName).ToList()));
        }

        private void AnalyzeType(TypeNode type)
        {
            var dependencies = new List<string>();
            dependencies.Add(type.BaseType.FullName);
            dependencies.AddRange(type.Interfaces.Select(i => i.FullName));
            //todo members & paramters
            classInfos.Add(type.FullName, Tuple.Create(type.ClassSize, dependencies));
        }
    }
}
