using andrena.Usus.net.View.Hub;
using Microsoft.Win32;

namespace andrena.Usus.net.Shell
{
    public class ShellViewModel
    {
        public ViewHub Hub { get; private set; }

        public ShellViewModel()
        {
            Hub = ViewHub.Instance;
        }

        public void AnalyzeClicked(System.Windows.Window owner)
        {
            var openFile = new OpenFileDialog();
            if (openFile.ShowDialog(owner) ?? false)
                ViewHub.Instance.StartAnalysis(openFile.FileName);
        }
    }
}
