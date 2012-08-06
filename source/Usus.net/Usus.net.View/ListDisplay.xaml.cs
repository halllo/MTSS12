using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace andrena.Usus.net.View
{
    public partial class ListDisplay : Window
    {
        public event Action<object> ItemClicked;

        public ListDisplay()
        {
            InitializeComponent();
            ItemClicked += i => { };
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ItemClicked((sender as ListBox).SelectedItem);
        }
    }
}
