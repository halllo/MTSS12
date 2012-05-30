﻿using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class MethodLengths
    {
        public static Object PropertyAutoImplemented
        {
            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectNumberOfStatements(1)]
            get;

            [ExpectNumberOfLogicalLines(0)]
            [ExpectNumberOfRealLines(0)]
            [ExpectNumberOfStatements(1)]
            set;
        }

        public static Object PropertyWithLogic
        {
            [ExpectNumberOfLogicalLines(2)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            get
            {
                return new NullReferenceException();
            }

            [ExpectNumberOfLogicalLines(1)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            set
            {
                value.ToString();
            }
        }

        public static Object PropertyGetterWithLogic
        {
            [ExpectNumberOfLogicalLines(2)]
            [ExpectNumberOfRealLines(1)]
            [ExpectNumberOfStatements(1)]
            get
            {
                return new NullReferenceException();
            }
        }

        [ExpectNumberOfLogicalLines(0)]
        [ExpectNumberOfRealLines(0)]
        [ExpectNumberOfStatements(0)]
        private void MethodWithNoLines_PrivateInstance()
        {
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(3)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithThreeLines()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithThreeLinesTwoEmtpyLines()
        {
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine();
        }

        [ExpectNumberOfLogicalLines(3)]
        [ExpectNumberOfRealLines(5)]
        [ExpectNumberOfStatements(3)]
        public static void MethodWithStatementInIfBlock()
        {
            bool c1 = true;
            if (c1)
            {
                Console.WriteLine();
            }
        }

        [ExpectNumberOfStatements(3)]
        public static void MethodWithStatementInIf()
        {
            bool c1 = true;
            if (c1) Console.WriteLine();
        }
    }
}
