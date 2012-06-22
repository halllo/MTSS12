using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.View.Hub;

namespace andrena.Usus.net.View.ViewModels
{
    public class Hotspots : IHubConnect
    {
        public ObservableCollection<HotspotEntry> Entries { get; private set; }
        public Hotspots()
        {
            Entries = new ObservableCollection<HotspotEntry>();
        }

        public void RegisterHub(ViewHub hub)
        {
            hub.MetricsReady += m => SetNewEntries(m.Hotspots());
        }

        private void SetNewEntries(MetricsHotspots hotspots)
        {
            Entries.Clear();
            var methodLengths = hotspots.OfMethodLength();

            foreach (var methodMetrics in methodLengths)
            {
                Entries.Add(new HotspotEntry { Name = methodMetrics.Name, Problem = methodMetrics.MethodLength.ToString() });
            }
        }
    }
}
