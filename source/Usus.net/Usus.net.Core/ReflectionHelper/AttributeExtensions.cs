using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public static class AttributeExtensions
    {
        public class MethodWithAttributes<T> where T : Attribute
        {
            public IEnumerable<T> Attributes { get; set; }
            public MethodInfo Method { get; set; }
        }

        public static IEnumerable<MethodWithAttributes<T>> GetMethodsWithAssigned<T>(this Assembly asm) where T : Attribute
        {
            return (from t in asm.GetTypes()
                    from m in t.GetMethods()
                    where m.Attributes<T>().Any()
                    select new MethodWithAttributes<T>
                    {
                        Method = m,
                        Attributes = m.Attributes<T>()
                    }).ToList();
        }

        private static IEnumerable<T> Attributes<T>(this MethodInfo method)
        {
            return method.GetCustomAttributes(typeof(T), false).Cast<T>();
        }
    }
}
