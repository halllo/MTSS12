using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public static class NumberOfLogicalLines
    {
        public static int Of(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                var locations = OperationLocation.From(method, pdb);
                return locations.GetAllStartLinesOfInterestingOpCodes().Distinct().Count();
            }
            return -1;
        }

        private static IEnumerable<int> GetAllStartLinesOfInterestingOpCodes(this IEnumerable<OperationLocation> locations)
        {
            return from l in locations
                   where l.OperationCode.IsOpCodeOfInterest() && l.IsValidLocation
                   select l.Location.StartLine;
        }

        private static bool IsOpCodeOfInterest(this OperationCode opCode)
        {
            return opCode != OperationCode.Nop
                && opCode != OperationCode.Leave_S
                && opCode != OperationCode.Ret;
        }
    }
}
