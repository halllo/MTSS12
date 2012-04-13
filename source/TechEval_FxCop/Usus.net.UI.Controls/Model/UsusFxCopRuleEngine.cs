using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace Usus.net.UI.Controls.Model
{
    internal class UsusFxCopRuleEngine
    {
        readonly string outputDirectory = @"D:\e\fxcop\";

        public IEnumerable<Method> Analyze(IEnumerable<string> files)
        {
            ClearOutputDirectory();
            CreateAnalysationFiles(files);
            System.Threading.Thread.Sleep(2000);//waiting for the files to appear on disk
            return ImportAnalysationFiles();
        }

        private IEnumerable<Method> ImportAnalysationFiles()
        {
            foreach (var file in Directory.GetFiles(outputDirectory))
                foreach (var line in File.ReadAllLines(file)) 
                    yield return CreateMethod(line);
        }

        private Method CreateMethod(string line)
        {
            var mn = line.Substring(0, line.IndexOf("->")).Trim();
            var nos = int.Parse(line.Substring(line.IndexOf("->") + 2, line.IndexOf("statements, ") - line.IndexOf("->") - 2).Trim());
            var cc = int.Parse(line.Substring(line.IndexOf(",") + 1, line.IndexOf("cc, ") - line.IndexOf(",") - 1).Trim());
            var cls = line.Substring(line.IndexOf("{"), line.IndexOf("}") - line.IndexOf("{") + 1);
            return new Method
            {
                Name = mn,
                Statements = nos,
                CyclomaticComplexity = cc,
                Callees = cls
            };
        }

        private void CreateAnalysationFiles(IEnumerable<string> files)
        {
            var ususRule = new UsusRuleIntrospection();
            foreach (var file in files) ususRule.Introspect(file);
        }

        private void ClearOutputDirectory()
        {
            foreach (var file in Directory.GetFiles(outputDirectory))
            {
                File.Delete(file);
            }
        }
    }
}
