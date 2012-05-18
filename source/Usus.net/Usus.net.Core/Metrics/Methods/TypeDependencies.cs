using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;
using Microsoft.Cci.Immutable;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public class TypeDependencies
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return Enumerable.Empty<string>()
                .Union(AnalyzeLocalVariables(method))
                .Union(AnalyzeCallOperations(method))
                .ToList();
        }

        #region Calls
        private static IEnumerable<string> AnalyzeCallOperations(IMethodDefinition method)
        {
            foreach (var operation in GetCallOperations(method))
            {
                yield return GetTypeOfMethod(operation).ToString();
            }
        }

        private static IEnumerable<IOperation> GetCallOperations(IMethodDefinition method)
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

        private static ITypeReference GetTypeOfMethod(IOperation operation)
        {
            return ((ITypeMemberReference)(operation.Value)).ContainingType;
        }
        #endregion

        #region Variables
        private static IEnumerable<string> AnalyzeLocalVariables(IMethodDefinition method)
        {
            return method.Body.LocalVariables.SelectMany(v => AnalyzeVariable(v));
        }

        private static IEnumerable<string> AnalyzeVariable(ILocalDefinition variable)
        {
            if (variable.Type is GenericTypeInstanceReference)
                return AnalyzeGenericVariable(variable.Type as GenericTypeInstanceReference);
            else
                return AnalyzeNonGenericVaribale(variable);
        }

        private static IEnumerable<string> AnalyzeNonGenericVaribale(ILocalDefinition variable)
        {
            yield return variable.Type.ToString();
        }

        private static IEnumerable<string> AnalyzeGenericVariable(GenericTypeInstanceReference variable)
        {
            yield return variable.GenericType.ToString();
            foreach (var genericArg in variable.GenericArguments)
            {
                yield return genericArg.ToString();
            }
        }
        #endregion
    }
}
