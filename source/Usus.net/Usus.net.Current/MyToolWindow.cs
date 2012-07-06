﻿using System;
using System.Runtime.InteropServices;
using andrena.Usus.net.ExtensionHelper;
using andrena.Usus.net.View;
using andrena.Usus.net.View.Hub;
using andrena.Usus.net.View.ViewModels.Current;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus_net_Current
{
    [Guid("8b59bcd8-3bf3-4222-98bd-908772a5a5f3")]
    public class MyToolWindow : BuildAwareToolWindowPane, IKnowSourceLocation
    {
        public MyToolWindow() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 2;

            BuildSuccessfull += files => ViewHub.Instance.TryStartAnalysis(files);
            base.Content = ViewFactory.CreateCurrent(ViewHub.Instance, this);
        }

        public LineLocation GetCursorPositon()
        {
            var cursor = CurrentCursor;
            return cursor != null ? new LineLocation { File = cursor.File, Line = cursor.Line } : null;
        }
    }
}
