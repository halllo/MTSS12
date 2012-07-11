﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using andrena.Usus.net.ExtensionHelper;

namespace andrena.Usus_net_Menus
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the PkgDef creation utility (CreatePkgDef.exe) that this class is
    // a package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    // This attribute is needed to let the shell know that this package exposes some menus.
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidUsus_net_MenusPkgString)]
    public sealed class Usus_net_MenusPackage : Package
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public Usus_net_MenusPackage()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }



        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Add our command handlers for menu (commands must exist in the .vsct file)
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            _Shell = GetService(typeof(SVsShell)) as IVsShell;
            if (null != mcs)
            {
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCockpit, MenuItemCallback_Cockpit);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetHotspots, MenuItemCallback_Hotspots);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetDistributions, MenuItemCallback_Distributions);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCleanCode, MenuItemCallback_CleanCode);
                SetupCommand(mcs, PkgCmdIDList.cmdidUsusNetCurrent, MenuItemCallback_Current);
            }
        }

        private static void SetupCommand(OleMenuCommandService mcs, uint cmdId, EventHandler cmdCallback)
        {
            CommandID menuCommandID = new CommandID(GuidList.guidUsus_net_MenusCmdSet, (int)cmdId);
            MenuCommand menuItem = new MenuCommand(cmdCallback, menuCommandID);
            mcs.AddCommand(menuItem);
        }
        #endregion


        IVsShell _Shell;

        private void MenuItemCallback_Cockpit(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Cockpit);
        }

        private void MenuItemCallback_Hotspots(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Hotspots);
        }

        private void MenuItemCallback_Distributions(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Distributions);
        }

        private void MenuItemCallback_CleanCode(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.CleanCode);
        }

        private void MenuItemCallback_Current(object sender, EventArgs e)
        {
            UsusNetWindow.Open(_Shell, UsusNetWindow.Current);
        }
    }
}