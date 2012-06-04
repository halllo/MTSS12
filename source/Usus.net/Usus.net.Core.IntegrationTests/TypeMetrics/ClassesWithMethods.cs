using System;
using andrena.Usus.net.Core.Verification;

namespace Usus.net.Core.IntegrationTests.TypeMetrics
{
    [ExpectNumberOfMethods(1)]//+ default ctor
    class ClassWithZeroMethods
    {
        static int i1;
        public static int i2;
        int i3;
    }

    [ExpectNumberOfMethods(2)]//+ default ctor
    class ClassWithOneMethod
    {
        static int i1;
        public static int i2;
        int i3;
        public void m() { }
    }

    [ExpectNumberOfMethods(3)]//+ default ctor
    class ClassWithOneMethodOneStatic
    {
        public int i1;
        public void m1() { }
        public static void m2() { }
    }

    [ExpectNumberOfMethods(2)]//+ default ctor
    class ClassWithMethods
    {
        public int i1;
        public void m() { }
    }

    class ClassWithSubClassAndMethods
    {
        [ExpectNumberOfMethods(3)]//+ default ctor
        class ClassWithMethods
        {
            public void m1() { }
            public void m2() { }
        }
    }

    [ExpectNumberOfMethods(1)]
    class ClassDefaultCtor
    {
        public int i1;
        public ClassDefaultCtor() { }
    }

    [ExpectNumberOfMethods(2)]
    static class StaticClassOneMethodAndCctor
    {
        static StaticClassOneMethodAndCctor() {}
        public static void m1() { }
    }

    [ExpectNumberOfMethods(3)]//+ default ctor
    class ClassWithGetterSetter
    {
        public int p1 { get; set; }
    }

    [ExpectNumberOfMethods(2)]//+ default ctor
    class ClassWithGetter
    {
        int i1;
        public int p1 { get { return i1; } }
    }
}
