using System;
using andrena.Usus.net.Core.Verification;
using System.Collections.Generic;

namespace Usus.net.Core.IntegrationTests.Methods
{
    public class Samples
    {
        [ExpectCyclomaticComplexity(6)]
        public static void MethodWithIfs()
        {
            bool c1 = true;
            bool c2 = true;
            bool c3 = true;
            bool c4 = false;
            if (c1)
            {
                if (c2 && c3 || c4)
                {
                    Console.WriteLine();
                }
                else if (c4)
                {
                    Console.WriteLine();
                }
            }
        }

        [ExpectTypeDependency("System.Console")]
        public static void MethodWithConsole()
        {
            Console.WriteLine("");
            Console.Write("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        [ExpectTypeDependency("System.Func")]
        [ExpectTypeDependency("System.NotFiniteNumberException")]
        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithFunc()
        {
            Func<NotFiniteNumberException> nfne = null;
            nfne.ToString().Substring(0, 5);
        }

        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.ArraySegment")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithNestedGenerics()
        {
            new List<IEnumerable<IList<ArraySegment<string>>>>();
        }
    }
}
