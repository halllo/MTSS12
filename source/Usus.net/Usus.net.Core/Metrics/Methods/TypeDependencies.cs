using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public class TypeDependencies
    {
        public static IEnumerable<string> Of(IMethodDefinition method)
        {
            return Enumerable.Empty<string>()
                .Union(GetTypesOfVariables(method))
                .Union(GetTypesOfCallOperations(method))
                .Union(GetTypesOfSignature(method))
                .Union(GetTypesOfNewOperations(method))
                .ToList();
        }

        #region Of Signature
        private static IEnumerable<string> GetTypesOfSignature(IMethodDefinition method)
        {
            return Enumerable.Empty<string>()
                .Union(GetReturnType(method))
                .Union(GetParameterTypes(method))
                .Union(GetTypesOfGenericsConstraints(method))
                .ToList();
        }

        private static IEnumerable<string> GetReturnType(IMethodDefinition method)
        {
            return from t in method.Type.GetAllRealTypeReferences()
                   select t.ToString();
        }

        private static IEnumerable<string> GetParameterTypes(IMethodDefinition method)
        {
            return from p in method.Parameters
                   from t in p.Type.GetAllRealTypeReferences()
                   where !(t is IGenericMethodParameter)
                   select t.ToString();
        }

        private static IEnumerable<string> GetTypesOfGenericsConstraints(IMethodDefinition method)
        {
            return from g in method.GenericParameters
                   from c in g.Constraints
                   from t in c.ResolvedType.GetAllRealTypeReferences()
                   select t.ToString();
        }
        #endregion

        #region Of Calls
        private static IEnumerable<string> GetTypesOfCallOperations(IMethodDefinition method)
        {
            return from o in GetCallOperations(method)
                   from t in GetDefiningTypeOfMethod(o)
                   select t.ToString();
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

        private static IEnumerable<ITypeReference> GetDefiningTypeOfMethod(IOperation operation)
        {
            var type = ((ITypeMemberReference)operation.Value).ContainingType;
            return type.GetAllRealTypeReferences();
        }
        #endregion

        #region Of Variables
        private static IEnumerable<string> GetTypesOfVariables(IMethodDefinition method)
        {
            return from v in method.Body.LocalVariables
                   from t in GetTypesOfVariable(v)
                   select t;
        }

        private static IEnumerable<string> GetTypesOfVariable(ILocalDefinition variable)
        {
            return from t in variable.Type.GetAllRealTypeReferences()
                   select t.ToString();
        }
        #endregion

        #region Of News
        private static IEnumerable<string> GetTypesOfNewOperations(IMethodDefinition method)
        {
            return from o in GetNewOperations(method)
                   select o.Value.ToString();
            //TODO get types form here
        }

        private static IEnumerable<IOperation> GetNewOperations(IMethodDefinition method)
        {
            return from o in method.Body.Operations
                   where IsNewOperation(o.OperationCode)
                   select o;
        }

        private static bool IsNewOperation(OperationCode o)
        {
            return o == OperationCode.Newobj;
        } 
        #endregion
    }
}
