using System.Windows.Controls.Primitives;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;
using andrena.Usus.net.View.ViewModels;

namespace andrena.Usus.net.View
{
    public partial class Hotspots : HubAwareControl
    {
        ViewModels.Hotspots viewModel;

        public Hotspots()
        {
            InitializeComponent();
            viewModel = new ViewModels.Hotspots { Dispatchable = this };
            DataContext = HubViewModel = viewModel;
        }

        public IJumpToSource SourceLocating { set { viewModel.Jumper = value; } }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selections = sender as MultiSelector;
            var selectedItem = selections.SelectedItem as IDoubleClickable;
            if (selectedItem != null) selectedItem.OnDoubleClick();
        }
    }
}
