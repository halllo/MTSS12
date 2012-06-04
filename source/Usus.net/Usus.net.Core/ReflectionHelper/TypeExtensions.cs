using System;

namespace andrena.Usus.net.Core.ReflectionHelper
{
    public static class TypeExtensions
    {
        public static string GetFullName(this Type type)
        {
            return Normalize.TypeName(type.ToString());
        }
    }
}
