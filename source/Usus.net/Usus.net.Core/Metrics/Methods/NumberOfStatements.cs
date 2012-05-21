using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    public static class NumberOfStatements
    {
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
    }
}
