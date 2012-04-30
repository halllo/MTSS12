// Guids.cs
// MUST match guids.h
using System;

namespace andrena.BuildSave
{
    static class GuidList
    {
        public const string guidBuildSavePkgString = "d54febd1-62de-45c7-8553-8bb301d8f450";
        public const string guidBuildSaveCmdSetString = "d25fbb17-dbac-4450-b2a7-af56d4984d1a";
        public const string guidToolWindowPersistanceString = "353f0be2-791f-440a-9609-d176005d4fb3";

        public static readonly Guid guidBuildSaveCmdSet = new Guid(guidBuildSaveCmdSetString);
    };
}