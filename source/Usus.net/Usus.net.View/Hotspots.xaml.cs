using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public partial class Hotspots : HubAwareControl
    {
        public Hotspots()
        {
            InitializeComponent();
            DataContext = HubViewModel = new ViewModels.Hotspots { Dispatchable = this };
        }
    }
}
