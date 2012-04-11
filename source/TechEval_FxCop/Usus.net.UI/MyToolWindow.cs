using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus_net_UI
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("00b2b9d5-b0dd-4f5a-a295-f3cea7b25ca2")]
    public class MyToolWindow : SolutionAwareToolWindowPane
    {
        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public MyToolWindow() :
            base(null)
        {
            // Set the window title reading it from the resources.
            this.Caption = Resources.ToolWindowTitle;
            // Set the image that will appear on the tab of the window frame
            // when docked with an other window
            // The resource ID correspond to the one defined in the resx file
            // while the Index is the offset in the bitmap strip. Each image in
            // the strip being 16x16.
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on 
            // the object returned by the Content property.

            var viewModel = new Usus.net.UI.Controls.ViewModel.SolutionView();
            base.SolutionChanged += () => viewModel.SetProjects(getProjects());
            base.SavingDone += () => viewModel.SetEvent(newEvent("save"));
            base.BuildDone += () => viewModel.SetEvent(newEvent("build"));

            base.Content = new Usus.net.UI.Controls.SolutionView(viewModel);
        }

        private Usus.net.UI.Controls.ViewModel.Event newEvent(string type)
        {
            return new Usus.net.UI.Controls.ViewModel.Event
            {
                Time = DateTime.Now,
                Type = type
            };
        }

        private IEnumerable<Usus.net.UI.Controls.ViewModel.Project> getProjects()
        {
            return from p in base.Projects
                   where !string.IsNullOrEmpty(p.FullName)
                   select new Usus.net.UI.Controls.ViewModel.Project
                   {
                       OutputAssembly = p.Properties.Item("OutputFileName").Value.ToString(),
                       ProjectPath = p.Properties.Item("FullPath").Value.ToString()
                   };                        
        }
    }
}
