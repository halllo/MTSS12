using System.Windows.Controls.Primitives;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public partial class Hotspots : HubAwareControl
    {
        public ViewModels.Hotspots.Hotspots ViewModel { get; private set; }

        public Hotspots()
        {
            InitializeComponent();
            RegisterViewModel(ViewModel = new ViewModels.Hotspots.Hotspots { Dispatchable = this });
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selections = sender as MultiSelector;
            ViewModel.DoubleClick(selections.SelectedItem);
        }
    }
}
