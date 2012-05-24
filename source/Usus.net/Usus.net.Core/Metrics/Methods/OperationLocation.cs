using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class OperationLocation
    {
        public IOperation Operation { get; set; }
        public OperationCode OperationCode
        {
            get { return Operation.OperationCode; }
        }

        public IPrimarySourceLocation Location { get; set; }
        public bool IsValidLocation
        {
            get { return Location.Length != 0; }
        }

        public static IEnumerable<OperationLocation> From(IMethodDefinition method, PdbReader pdb)
        {
            return (from o in method.Body.Operations
                    from l in pdb.GetPrimarySourceLocationsFor(o.Location)
                    select new OperationLocation { Operation = o, Location = l }).ToList();
        }
    }
}
