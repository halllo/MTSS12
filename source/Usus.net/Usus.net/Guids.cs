// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus.net
{
    static class GuidList
    {
        public const string guidUsus_netPkgString = "ebded51e-e646-4863-bbcc-f12d9799741a";
        public const string guidUsus_netCmdSetString = "021277a1-40a3-40f9-a60e-45ee0adefeff";
        public const string guidToolWindowPersistanceString = "fd29826d-3055-4ae3-aed7-229fff349a20";

        public static readonly Guid guidUsus_netCmdSet = new Guid(guidUsus_netCmdSetString);
    };
}