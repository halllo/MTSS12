using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Cci;
using System.IO;

namespace TechEval_CCI_MC
{
    public static class MethodLength
    {
        /// <summary>
        /// Taken from 
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static int Of(IMethodDefinition method)
        {
            int num = 0;
            bool flag = false;
            foreach (var operation in method.Body.Operations)
            {
                if (operation.OperationCode != OperationCode.Ret)
                {
                    flag = true;
                }
                num += 1;
            }
            if (flag)
            {
                num = (int)Math.Max((double)num, 5.0);
            }
            return (int)Math.Round((double)(((double)num) / 5.0));
        }

        public static int WithSymbols(IMethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                var locations = method.GetAllLocations(pdb);
                if (locations.Any()) return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static IEnumerable<IPrimarySourceLocation> GetAllLocations(this IMethodDefinition method, PdbReader pdb)
        {
            return method.Body.Operations.SelectMany(o => pdb.GetPrimarySourceLocationsFor(o.Location)).ToList();
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<IPrimarySourceLocation> locations)
        {
            var startLine = locations.GetAllLines(l => l.EndLine).Min();
            var endLine = locations.GetAllLines(l => l.EndLine).Max();
            return Math.Max(0, endLine - startLine - 1);
        }

        private static IEnumerable<int> GetAllLines(this IEnumerable<IPrimarySourceLocation> locations, Func<IPrimarySourceLocation, int> line)
        {
            return from l in locations
                   where l.Length != 0
                   select line(l);
        }
    }
}
