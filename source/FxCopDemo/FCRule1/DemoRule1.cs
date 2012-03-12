using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;
using System.IO;

namespace FCRule1
{
    public class DemoRule1 : BaseIntrospectionRule
    {
        Dictionary<string, int> methodLengths;

        public DemoRule1()
            : base("DemoRule1", "FCRule1.FCRule1", typeof(DemoRule1).Assembly)
        {
            methodLengths = new Dictionary<string, int>();
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
            string newFileName = @"C:\t\" + DateTime.Now.Ticks + ".txt";
            using (var fileStream = new StreamWriter(File.Create(newFileName)))
            {
                foreach (var line in methodLengths.Select((m) => m.Key + "\t->\t" + m.Value))
                {
                    fileStream.WriteLine(line);
                }
            }
            base.AfterAnalysis();
        }

        public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null)
            {
                var stCount = method.Body.Statements.Count;
                methodLengths.Add(member.FullName, stCount);
            }

            return this.Problems;
        }
    }
}
