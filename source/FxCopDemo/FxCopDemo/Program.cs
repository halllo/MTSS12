using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.FxCop.Sdk;
using System.Diagnostics;

namespace FxCopDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string toAnalyse = @"C:\Users\Manuel Naujoks\Documents\Visual Studio 2010\Projects\SilverlightRun\SilverlightRun\Bin\Release\SilverlightRun.dll";
            string rule = @"C:\Users\Manuel Naujoks\Documents\Visual Studio 2010\Projects\FxCopDemo\FCRule1\bin\Debug\FCRule1.dll";
            string fxCop = @"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe";

            IntrospectUsingFxCopCMD(fxCop, toAnalyse, rule);
        }
  
        private static void IntrospectUsingFxCopCMD(string fxCop, string toAnalyse, string rule)
        {
            var processStartInfo = new ProcessStartInfo(fxCop, "/file:\"" + toAnalyse + "\" /rule:\"" + rule + "\" /console");
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            var fxCopProcess = Process.Start(processStartInfo);
        }
  
        private static void IntrospectUsingFxCopAPI_DoesNotWork(string toAnalyse)
        {
            var asm = AssemblyNode.GetAssembly(toAnalyse);
            Console.WriteLine(asm.GetAssemblyName());
            foreach (var type in asm.Types)
            {
                Console.WriteLine("\t" + type.FullName);
                foreach (var member in type.Members)
                {
                    Method method = member as Method;
                    if (method != null)
                    {
                        Console.WriteLine("\t\t" + method.Name);
                    }
                }
            }
        }
    }
}
