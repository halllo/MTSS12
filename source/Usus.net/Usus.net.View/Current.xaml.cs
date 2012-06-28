using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    /// <summary>
    /// Interaction logic for Current.xaml
    /// </summary>
    public partial class Current : HubAwareControl
    {
        public Current()
        {
            InitializeComponent();
            DataContext = HubViewModel = new ViewModels.Current.Current { Dispatchable = this };
        }
    }
}
