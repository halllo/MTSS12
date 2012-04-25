using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Mono.Cecil.Cil;
using Mono.Cecil.Pdb;
using Mono.Cecil;

namespace TechEval_NRefactory
{
    public static class CecilTries
    {
        public static void ReadAssembly(string toAnalyze)
        {
            var pdbReader = ReadAssemblyWithPdb(toAnalyze);
            var asm = AssemblyDefinition.ReadAssembly(toAnalyze);
            OutputAssembly(pdbReader, asm);
        }
        private static void OutputAssembly(ISymbolReader pdbReader, AssemblyDefinition asm)
        {
            Console.WriteLine(asm.FullName);
            foreach (var module in asm.Modules)
            {
                OutputModule(pdbReader, module);
            }
        }
        private static void OutputModule(ISymbolReader pdbReader, ModuleDefinition module)
        {
            Console.WriteLine("\t" + module.FullyQualifiedName);
            foreach (TypeDefinition type in module.Types)
            {
                OutputType(pdbReader, type);
            }
        }
        private static void OutputType(ISymbolReader pdbReader, TypeDefinition type)
        {
            Console.WriteLine("\t\t" + type.FullName);
            foreach (MethodDefinition method in type.Methods)
            {
                OutputMethod(pdbReader, method);
            }
            Console.WriteLine();
        }
        private static void OutputMethod(ISymbolReader pdbReader, MethodDefinition method)
        {
            Console.WriteLine("\t\t\t" + method.FullName);
            foreach (Instruction instruction in method.Body.Instructions)
            {
                Console.WriteLine("\t\t\t\t" + instruction.OpCode.ToString());
            }
        }
        private static ISymbolReader ReadAssemblyWithPdb(string toAnalyze)
        {
            var pdb = new PdbReaderProvider();
            string pdbFile = Path.ChangeExtension(toAnalyze, "pdb");
            var moduleToAnalyze = ModuleDefinition.ReadModule(toAnalyze);
            return pdb.GetSymbolReader(moduleToAnalyze, pdbFile);
        }
    }
}
