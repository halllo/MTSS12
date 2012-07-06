using System.Windows;
using andrena.Usus.net.View.ExtensionPoints;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View
{
    public static class ViewFactory
    {
        public static FrameworkElement CreateCockpit(ViewHub hub)
        {
            var cockpitView = new View.Cockpit();
            var cockpitViewModel = new View.ViewModels.Cockpit.Cockpit { Dispatchable = cockpitView };
            cockpitViewModel.RegisterHub(hub);
            cockpitView.DataContext = cockpitViewModel;
            return cockpitView;
        }

        public static FrameworkElement CreateDistributions(ViewHub hub)
        {
            var distributionsView = new View.Distributions();
            var distributionsViewModel = new View.ViewModels.Distributions.Distributions { Dispatchable = distributionsView };
            distributionsViewModel.RegisterHub(hub);
            distributionsView.DataContext = distributionsViewModel;
            return distributionsView;
        }

        public static FrameworkElement CreateCurrent(ViewHub hub, IKnowSourceLocation knowCursorPositon)
        {
            var currentView = new View.Current();
            var currentViewModel = new View.ViewModels.Current.Current { Dispatchable = currentView };
            currentViewModel.RegisterHub(hub);
            currentViewModel.SourceLocations = knowCursorPositon;
            currentView.DataContext = currentViewModel;
            return currentView;
        }

        public static FrameworkElement CreateHotspots(ViewHub hub, IJumpToSource jumpToSource)
        {
            var hotspotsView = new View.Hotspots();
            var hotspotsViewModel = new View.ViewModels.Hotspots.Hotspots { Dispatchable = hotspotsView };
            hotspotsViewModel.RegisterHub(hub);
            hotspotsViewModel.SourceLocating = jumpToSource;
            hotspotsView.DataContext = hotspotsViewModel;
            return hotspotsView;
        }
    }
}
