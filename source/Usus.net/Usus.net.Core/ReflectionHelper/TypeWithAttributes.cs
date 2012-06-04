using System;
using System.Collections.Generic;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public class TypeWithAttributes<T> where T : Attribute
    {
        public IEnumerable<T> Attributes { get; set; }
        public Type Type { get; set; }
    }
}
