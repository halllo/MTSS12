using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.Immutable;

namespace andrena.Usus.net.Core
{
    public static class MethodExtensions
    {
        public static void Analyze(this IMethodDefinition method, PdbReader pdb)
        {
            //Console.WriteLine("\t" + method.Name);
            AnalyzeLocalVariables(method);
            AnalyzeCallOperations(method);
            //Console.WriteLine("\t\tcc: " + CyclomaticComplexity.Of(method));
            //Console.WriteLine("\t\tml: " + MethodLength.Of(method));
            //Console.WriteLine("\t\tms: " + MethodLength.WithSymbols(method, pdb));
        }

        private static void AnalyzeCallOperations(IMethodDefinition method)
        {
            foreach (var operation in getCallOperations(method))
            {
                //Console.WriteLine("\t\t" + getTypeOfMethod(operation));
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
            //Console.WriteLine("\t\t" + variable.Type.ToString());
        }

        private static void AnalyzeGenericVariable(GenericTypeInstanceReference variable)
        {
            //Console.WriteLine("\t\t" + variable.GenericType.ToString());
            foreach (var genericArg in variable.GenericArguments)
            {
                //Console.WriteLine("\t\t\t" + genericArg.ToString());
            }
        }
    }
}
