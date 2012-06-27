using System;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace andrena.Usus.net.ExtensionHelper
{
    public class DtAwareToolWindow : ToolWindowPane
    {
        private EnvDTE80.DTE2 CachedDt2;
        protected EnvDTE80.DTE2 MasterObjekt
        {
            get
            {
                if (CachedDt2 == null) CachedDt2 = base.GetService(typeof(SDTE)) as EnvDTE80.DTE2;
                return CachedDt2;
            }
        }

        public DtAwareToolWindow(IServiceProvider isp)
            : base(isp)
        {
        }

        protected void OpenFileAtLine(string fileName, int line, bool select)
        {
            MasterObjekt.ItemOperations.OpenFile(fileName, EnvDTE.Constants.vsViewKindTextView);
            EnvDTE.TextSelection sourceText = MasterObjekt.ActiveDocument.Selection as EnvDTE.TextSelection;
            sourceText.GotoLine(line, select);
        }
    }
}
