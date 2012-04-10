// Guids.cs
// MUST match guids.h
using System;

namespace andrena.Usus_net_UI
{
    static class GuidList
    {
        public const string guidUsus_net_UIPkgString = "bbd8efb8-f9e7-408d-93b7-43542a390354";
        public const string guidUsus_net_UICmdSetString = "34bb3d88-ab95-4c6d-af64-6b74340a5122";
        public const string guidToolWindowPersistanceString = "00b2b9d5-b0dd-4f5a-a295-f3cea7b25ca2";

        public static readonly Guid guidUsus_net_UICmdSet = new Guid(guidUsus_net_UICmdSetString);
    };
}