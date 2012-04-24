using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

namespace TechEval_NRefactory
{
    public static class EmbeddedResource
    {
        public static void Read(string file, Action<string> reader)
        {
            using (StreamReader stream = GetStream(file))
                reader(stream.ReadToEnd());
        }
        private static StreamReader GetStream(string file)
        {
            return new StreamReader(
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                String.Format("TechEval_NRefactory.{0}", file)));
        }
    }
}
