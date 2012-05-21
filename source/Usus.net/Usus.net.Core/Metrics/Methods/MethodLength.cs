using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public static class MethodLength
    {
        private class OperationLocation
        {
            public IOperation Operation { get; set; }
            public IPrimarySourceLocation Location { get; set; }
        }

        #region Logical Lines
        public static int LogicalLinesOf(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                var locations = method.GetLocatedOperations(pdb);
                return locations.GetAllStartLinesOfInterestingOpCodes().Distinct().Count();
            }
            return -1;
        }

        private static IEnumerable<int> GetAllStartLinesOfInterestingOpCodes(this IEnumerable<OperationLocation> locations)
        {
            return from l in locations
                   where l.Operation.OperationCode.IsOpCodeOfInterest() 
                   && l.Location.IsValidLocation()
                   select l.Location.StartLine;
        }

        private static bool IsOpCodeOfInterest(this OperationCode opCode)
        {
            return opCode != OperationCode.Nop
                && opCode != OperationCode.Leave_S
                && opCode != OperationCode.Ret;
        }
        #endregion

        #region Real Lines
        public static int RealLinesOf(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                var locations = method.GetLocatedOperations(pdb).Select(ol => ol.Location);
                return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static IEnumerable<OperationLocation> GetLocatedOperations(this IMethodDefinition method, PdbReader pdb)
        {
            return (from o in method.Body.Operations
                    from l in pdb.GetPrimarySourceLocationsFor(o.Location)
                    select new OperationLocation { Operation = o, Location = l }).ToList();
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<IPrimarySourceLocation> locations)
        {
            if (!locations.Any()) return 0;
            var startLine = locations.GetAllValidLines(l => l.EndLine).Min();
            var endLine = locations.GetAllValidLines(l => l.EndLine).Max();
            return Math.Max(0, endLine - startLine - 1);
        }

        private static IEnumerable<int> GetAllValidLines(this IEnumerable<IPrimarySourceLocation> locations, Func<IPrimarySourceLocation, int> line)
        {
            return from l in locations
                   where l.IsValidLocation()
                   select line(l);
        }

        private static bool IsValidLocation(this IPrimarySourceLocation location)
        {
            return location.Length != 0;
        }
        #endregion
    }
}
