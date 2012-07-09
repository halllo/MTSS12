using andrena.Usus.net.View.ViewModels.Current;
using System;

namespace andrena.Usus_net_Current
{
    public static class Relay
    {
        internal static Usus_net_CurrentPackage PackageInstance { private get; set; }
        internal readonly static LocationPush LocationPush = new LocationPush();

        public static void Show(LineLocation lineLocation)
        {
            if (PackageInstance != null) PackageInstance.ShowToolWindow();
            LocationPush.Push(lineLocation);
        }
    }
}
