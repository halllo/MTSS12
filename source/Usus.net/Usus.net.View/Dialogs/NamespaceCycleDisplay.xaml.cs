using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace andrena.Usus.net.View.Dialogs
{
    public partial class NamespaceCycleDisplay : Window
    {
        public NamespaceCycleDisplay()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem;
            if (selectedItem != null)
            {
                var vm = DataContext as NamespaceCycleDisplayVM;
                vm.Select(selectedItem as string);
            }
        }
    }
}
