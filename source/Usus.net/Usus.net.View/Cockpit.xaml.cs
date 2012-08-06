using System.Windows.Controls;
using System.Windows.Threading;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View
{
    public partial class Cockpit : UserControl
    {
        public ViewModels.Cockpit.Cockpit ViewModel { get { return DataContext as ViewModels.Cockpit.Cockpit; } }

        public Cockpit()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var listDisplay = new View.ListDisplay();
            listDisplay.ItemClicked += i => ViewModel.JumpToMethod(i as MethodMetricsReport);
            listDisplay.DataContext = CreateChangedMethods(listDisplay);
            listDisplay.Show();
        }

        private ViewModels.ListDisplay<MethodMetricsReport> CreateChangedMethods(DispatcherObject listDisplay)
        {
            var methodChanges = new ViewModels.ListDisplay<MethodMetricsReport>("Changed Methods") { Dispatchable = listDisplay };
            methodChanges.AddEntries(ViewModel.ChangedMethods);
            return methodChanges;
        }
    }
}
