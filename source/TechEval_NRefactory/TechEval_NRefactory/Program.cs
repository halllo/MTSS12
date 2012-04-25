using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;

namespace TechEval_NRefactory
{
    class Program
    {
        static void Main()
        {
            NRefactoryTries.ReadAndParseFile("Code1.txt");
            //CecilTries.ReadAssembly(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            Console.ReadLine();
        }
    }
}