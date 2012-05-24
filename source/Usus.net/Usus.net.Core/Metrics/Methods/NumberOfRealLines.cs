using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public static class NumberOfRealLines
    {
        public static int Of(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                var locations = OperationLocation.From(method, pdb);
                return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<OperationLocation> locations)
        {
            if (!locations.Any()) return 0;
            var startLine = locations.GetAllValidLines(l => l.EndLine).Min();
            var endLine = locations.GetAllValidLines(l => l.EndLine).Max();
            return Math.Max(0, endLine - startLine - 1);
        }

        private static IEnumerable<int> GetAllValidLines(this IEnumerable<OperationLocation> locations, Func<IPrimarySourceLocation, int> line)
        {
            return from l in locations
                   where l.IsValidLocation
                   select line(l.Location);
        }
    }
}
