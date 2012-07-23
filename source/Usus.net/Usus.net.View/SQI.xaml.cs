using System.Windows.Controls;

namespace andrena.Usus.net.View
{
    public partial class SQI : UserControl
    {
        public ViewModels.SQI.SQI ViewModel { get { return DataContext as ViewModels.SQI.SQI; } }

        public SQI()
        {
            InitializeComponent();
        }
    }
}
