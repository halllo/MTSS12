using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View.Hub;
using View = andrena.Usus.net.View;
using ViewModel = andrena.Usus.net.View.ViewModels.Current;

namespace andrena.Usus_net_Current
{
    [Guid("8b59bcd8-3bf3-4222-98bd-908772a5a5f3")]
    public class MyToolWindow : BuildAwareToolWindowPane
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = CreateCurrentView();
        }

        private View.Current CreateCurrentView()
        {
            var currentView = new View.Current() { Hub = ViewHub.Instance };
            currentView.ViewModel.RequestCurosrPosition = GetCursorPositon;
            return currentView;
        }

        private ViewModel.LineLocation GetCursorPositon()
        {
            var cursor = CurrentCursor;
            return cursor != null ? new ViewModel.LineLocation { File = cursor.File, Line = cursor.Line } : null;
        }
    }
}
