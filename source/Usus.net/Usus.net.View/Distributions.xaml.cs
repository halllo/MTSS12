using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public partial class Distributions : HubAwareControl
    {
        public Distributions()
        {
            InitializeComponent();
            RegisterViewModel(new ViewModels.Distributions.Distributions { Dispatchable = this });
        }
    }
}
