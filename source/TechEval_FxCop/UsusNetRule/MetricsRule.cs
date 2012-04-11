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
        Dictionary<string, Tuple<int, int>> methodLengths;

        public MetricsRule()
            : base("MetricsRule", "UsusNetRule.UsusNetRule", typeof(MetricsRule).Assembly)
        {
            methodLengths = new Dictionary<string, Tuple<int, int>>();
        }

        public override TargetVisibilities TargetVisibility
        {
            get
            {
                return TargetVisibilities.All;
            }
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

        private static void CreateOutputDirectory(string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
        }

        private void CreateOutputFile(string newFileName)
        {
            using (var fileStream = new StreamWriter(File.Create(newFileName)))
            {
                foreach (var line in GetLinesFrom(methodLengths))
                {
                    fileStream.WriteLine(line);
                }
            }
        }

        private IEnumerable<string> GetLinesFrom(IEnumerable<KeyValuePair<string, Tuple<int, int>>> methods)
        {
            return methods.Select((m) => m.Key + "\t->\t" 
                + m.Value.Item1 + " statements, " 
                + m.Value.Item2 + " instructions");
        }

        public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null)
            {
                var stCount = method.Body.Statements.Count;
                var inCount = method.Instructions.Count;
                methodLengths.Add(member.FullName, Tuple.Create(stCount, inCount));
            }

            return this.Problems;
        }
    }
}
