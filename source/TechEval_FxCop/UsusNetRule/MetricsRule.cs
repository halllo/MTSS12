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

        public MetricsRule()
            : base("MetricsRule", "UsusNetRule.UsusNetRule", typeof(MetricsRule).Assembly)
        {
            methodInfos = new Dictionary<string, Tuple<int, int, List<string>>>();
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

        public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null)
            {
                var stCount = method.NumberOfLines();
                var types = method.ReferencedTypes();
                var cc = method.CyclomaticComplexity();
                methodInfos.Add(member.FullName, Tuple.Create(stCount, cc, types.Select(t => t.FullName).ToList()));
            }

            return this.Problems;
        }
    }
}
