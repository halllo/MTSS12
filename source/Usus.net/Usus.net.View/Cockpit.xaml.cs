using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public partial class Cockpit : HubAwareControl
    {
        public Cockpit()
        {
            InitializeComponent();
            DataContext = HubViewModel = new ViewModels.Cockpit();
        }
    }
}
