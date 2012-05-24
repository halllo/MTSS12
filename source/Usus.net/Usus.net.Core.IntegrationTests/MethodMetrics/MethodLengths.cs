using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class MethodLengths
    {
        [ExpectNumberOfLogicalLines(0)]
        [ExpectNumberOfRealLines(0)]
        private void MethodWithNoLines_PrivateInstance()
        {
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(3)]
        public static void MethodWithThreeLines()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        public static void MethodWithThreeLinesTwoEmtpyLines()
        {
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        public static void MethodWithThreeLinesTwoBraceLines()
        {
            bool c1 = true;
            if (c1)
            {
                Console.WriteLine();
            }
        }

        [ExpectNumberOfStatements(3)]
        public static void MethodWithStatementInIfBlock()
        {
            bool c1 = true;
            if (c1)
            {
                Console.WriteLine();
            }
        }

        [ExpectNumberOfStatements(2)]
        public static void MethodWithStatementInIf()
        {
            bool c1 = true;
            if (c1) Console.WriteLine();
        }
    }
}
