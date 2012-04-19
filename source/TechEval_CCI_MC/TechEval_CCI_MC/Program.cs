using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using Microsoft.Cci.Immutable;
using System.IO;

namespace TechEval_CCI_MC
{
    public class Program
    {

        public static void Main(string[] args)
        {
            AnalyzeFile(@"C:\Users\mnaujoks\Documents\Visual Studio 2010\Projects\ConsoleApplication2\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe");
            Console.ReadLine();
        }

        private static void AnalyzeFile(string toAnalyse)
        {
            using (var host = new PeReader.DefaultHost())
                AnalyzeFileInHost(toAnalyse, host);
        }

        private static void AnalyzeFileInHost(string toAnalyse, IMetadataHost host)
        {
            AnalyzeFileWithPdb(toAnalyse, host, (pdb) =>
            {
                AnalyzeAssembly(host.LoadUnitFrom(toAnalyse) as IAssembly, pdb);
            });
        }

        private static void AnalyzeFileWithPdb(string toAnalyse, IMetadataHost host, Action<PdbReader> pdbReader)
        {
            string pdbFile = Path.ChangeExtension(toAnalyse, "pdb");
            if (File.Exists(pdbFile))
                using (var pdb = new PdbReader(File.OpenRead(pdbFile), host))
                    pdbReader(pdb);
            else
                pdbReader(null);
        }

        private static void AnalyzeAssembly(IAssembly assembly, PdbReader pdb)
        {
            foreach (var type in getTypesNotGenerated(assembly))
                AnalyzeType(type, pdb);
        }

        private static IEnumerable<INamedTypeDefinition> getTypesNotGenerated(IAssembly assembly)
        {
            return from t in assembly.GetAllTypes()
                   where !HasAnyGeneratedCodeAttributes(t)
                   select t;
        }

        private static bool HasAnyGeneratedCodeAttributes(IReference r)
        {
            return r.Attributes.Any((a => IsGeneratedCodeAttribute(a)));
        }

        private static bool IsGeneratedCodeAttribute(ICustomAttribute a)
        {
            return a.Type.ToString().Contains("CompilerGeneratedAttribute");
        }

        private static void AnalyzeType(INamedTypeDefinition type, PdbReader pdb)
        {
            Console.WriteLine(type.ToString());
            foreach (var method in getMethodsNotGenerated(type))
                AnalyzeMethod(method, pdb);
            Console.WriteLine();
        }

        private static IEnumerable<IMethodDefinition> getMethodsNotGenerated(INamedTypeDefinition type)
        {
            return from t in type.Methods
                   where !HasAnyGeneratedCodeAttributes(t)
                   select t;
        }

        private static void AnalyzeMethod(IMethodDefinition method, PdbReader pdb)
        {
            Console.WriteLine("\t" + method.Name);
            AnalyzeLocalVariables(method);
            AnalyzeCallOperations(method);
            Console.WriteLine("\t\tcc: " + CyclomaticComplexity.Of(method));
            Console.WriteLine("\t\tml: " + MethodLength.Of(method));
            Console.WriteLine("\t\tms: " + MethodLength.WithSymbols(method, pdb));
        }

        private static void AnalyzeCallOperations(IMethodDefinition method)
        {
            foreach (var operation in getCallOperations(method))
            {
                Console.WriteLine("\t\t" + getTypeOfMethod(operation));
            }
        }

        private static ITypeReference getTypeOfMethod(IOperation operation)
        {
            return ((ITypeMemberReference)(operation.Value)).ContainingType;
        }

        private static IEnumerable<IOperation> getCallOperations(IMethodDefinition method)
        {
            return from o in method.Body.Operations
                   where IsCallOperation(o.OperationCode)
                   select o;
        }

        private static bool IsCallOperation(OperationCode o)
        {
            return o == OperationCode.Call
                || o == OperationCode.Calli
                || o == OperationCode.Callvirt;
        }

        private static void AnalyzeLocalVariables(IMethodDefinition method)
        {
            foreach (var variable in method.Body.LocalVariables)
                AnalyzeVariable(variable);
        }

        private static void AnalyzeVariable(ILocalDefinition variable)
        {
            if (variable.Type is GenericTypeInstanceReference)
                AnalyzeGenericVariable(variable.Type as GenericTypeInstanceReference);
            else
                AnalyzeNonGenericVaribale(variable);
        }

        private static void AnalyzeNonGenericVaribale(ILocalDefinition variable)
        {
            Console.WriteLine("\t\t" + variable.Type.ToString());
        }

        private static void AnalyzeGenericVariable(GenericTypeInstanceReference variable)
        {
            Console.WriteLine("\t\t" + variable.GenericType.ToString());
            foreach (var genericArg in variable.GenericArguments)
            {
                Console.WriteLine("\t\t\t" + genericArg.ToString());
            }
        }
    }
}
