using System;
using System.Collections.Generic;
using System.Reflection;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public class MethodWithAttributes<T> where T : Attribute
    {
        public IEnumerable<T> Attributes { get; set; }
        public MethodInfo Method { get; set; }
    }
}
