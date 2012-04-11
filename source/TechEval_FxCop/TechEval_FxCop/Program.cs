using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TechEval_FxCop
{
    class Program
    {
        static void Main(string[] args)
        {
            string toAnalyse = @"D:\manuel\Git\GitHub\MTSS12\source\TechEval_FxCop\UsusNetRule\bin\Debug\UsusNetRule.dll";

            UsusRuleIntrospection ususRule = new UsusRuleIntrospection();
            ususRule.Introspect(toAnalyse);

            Console.WriteLine("\nDone!");
            Console.ReadLine();
        }
    }
}
