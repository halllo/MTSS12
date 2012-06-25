using System.Windows;
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

        public void AnalyzeClicked(Window owner)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(owner) ?? false)
                StartAnalysis(openFileDialog.FileName);
        }

        private void StartAnalysis(string openFile)
        {
            ViewHub.Instance.StartAnalysis(openFile);
        }
    }
}
