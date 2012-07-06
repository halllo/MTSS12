using System.Windows.Controls;

namespace andrena.Usus.net.View
{
    public partial class Current : UserControl
    {
        public ViewModels.Current.Current ViewModel { get { return DataContext as ViewModels.Current.Current; } }

        public Current()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.RequestMetrics();
        }
    }
}
