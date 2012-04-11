using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Usus.net.UI.Controls
{
    /// <summary>
    /// Interaction logic for SolutionView.xaml
    /// </summary>
    public partial class SolutionView : UserControl
    {
        ViewModel.SolutionView viewModel;

        public SolutionView(ViewModel.SolutionView viewModel)
        {
            InitializeComponent();
            DataContext = this.viewModel = viewModel;
        }
    }
}
