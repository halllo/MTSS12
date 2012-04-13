using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Usus.net.UI.Controls.Model
{
    public class UsusRuleIntrospection
    {
        readonly string rule = @"D:\manuel\Git\GitHub\MTSS12\source\TechEval_FxCop\UsusNetRule\bin\Debug\UsusNetRule.dll";
        readonly string fxCop = @"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe";
            
        public void Introspect(string assembly)
        {
            IntrospectUsingFxCopCMD(fxCop, assembly, rule);
        }

        private static void IntrospectUsingFxCopCMD(string fxCop, string toAnalyse, string rule)
        {
            string cmdArgs = "/file:\"" + toAnalyse + "\" /rule:\"" + rule + "\" /console";
            var processStartInfo = new ProcessStartInfo(fxCop, cmdArgs);
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var fxCopProcess = Process.Start(processStartInfo);
        }
    }
}
