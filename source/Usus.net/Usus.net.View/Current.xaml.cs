using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public partial class Current : HubAwareControl
    {
        public ViewModels.Current.Current ViewModel { get; private set; }

        public Current()
        {
            InitializeComponent();
            RegisterViewModel(ViewModel = new ViewModels.Current.Current { Dispatchable = this });
        }

        private void DataGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ViewModel.RequestMetrics();
        }
    }
}
