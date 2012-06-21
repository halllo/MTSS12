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

        public IHubConnect HubViewModel { get; protected set; }

        private void HubAssigned(ViewHub hub)
        {
            if (HubViewModel != null) HubViewModel.RegisterHub(hub);
        }
    }
}
