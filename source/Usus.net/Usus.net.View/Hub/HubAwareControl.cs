using System.Windows;
using System.Windows.Controls;

namespace andrena.Usus.net.View.Hub
{
    public class HubAwareControl : UserControl
    {
        public ViewHub Hub
        {
            get { return (ViewHub)GetValue(HubProperty); }
            set { SetValue(HubProperty, value); }
        }

        public static readonly DependencyProperty HubProperty = DependencyProperty.Register("Hub", typeof(ViewHub), typeof(HubAwareControl), new UIPropertyMetadata(null, new PropertyChangedCallback(HubChanged)));

        public static void HubChanged(DependencyObject dpe, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is ViewHub) (dpe as HubAwareControl).HubAssigned(e.NewValue as ViewHub);
        }

        IHubConnect hubViewModel;
        protected void RegisterViewModel(IHubConnect hubViewModel)
        {
            DataContext = this.hubViewModel = hubViewModel;
        }

        private void HubAssigned(ViewHub hub)
        {
            if (hubViewModel != null) hubViewModel.RegisterHub(hub);
        }
    }
}
