using System;
using System.Collections.Generic;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.MethodMetrics
{
    public class TypeDependencies
    {
        public AccessViolationException PropertyAutoImplemented
        {
            [ExpectTypeDependency("System.AccessViolationException")]
            get;

            [ExpectTypeDependency("System.AccessViolationException")]
            set;
        }

        public Exception PropertyWithLogic
        {
            [ExpectTypeDependency("System.Exception")]
            [ExpectTypeDependency("System.NullReferenceException")]
            get
            {
                return new NullReferenceException();
            }
            [ExpectTypeDependency("System.Exception")]
            set
            {
                value.ToString();
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

        [ExpectTypeDependency("System.Collections.Generic.ICollection")]
        [ExpectTypeDependency("System.String")]
        public static void MethodWithGenericConstraints<T, R>(T t)
            where T : class
            where R : ICollection<string>
        {
            return;
        }

        [ExpectTypeDependency("System.Exception")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static Exception MethodWithNoGenericsInSignature(NotImplementedException e)
        {
            return e;
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectTypeDependency("System.NotImplementedException")]
        public static IList<Object> MethodWithGenericsInSignature(IEnumerable<NotImplementedException> e)
        {
            return new List<Object>();
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.List")]
        [ExpectTypeDependency("System.Collections.Generic.IList")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        public static IEnumerable<IList<Object>> MethodWithNestedGenericsInSignature()
        {
            return new List<List<Object>>();
        }

        [ExpectTypeDependency("System.Object")]
        [ExpectTypeDependency("System.Collections.Generic.IEnumerable")]
        [ExpectNoTypeDependency("System.NotImplementedException")]//iterators not yet supported!
        public static IEnumerable<Object> MethodWithYieldReturn()
        {
            yield return new NotImplementedException();
        }

        [ExpectNoTypeDependency("System.Object")]
        public static void MethodWithNoObject()
        {
            return;
        }

        [ExpectTypeDependency("System.NotImplementedException")]
        [ExpectTypeDependency("System.NotFiniteNumberException")]
        public static void MethodWithTryCatch()
        {
            try
            {
                Console.WriteLine();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine();
            }
            catch (NotFiniteNumberException)
            {
                Console.WriteLine();
            }
        }
    }
}
