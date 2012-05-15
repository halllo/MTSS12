using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace BuildSaveUi
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BuildSaveView : UserControl
    {
        public BuildSaveView(BuildSaveViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
