using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.ViewModels
{
    public class Cockpit
    {
        public ObservableCollection<CockpitEntry> Entries { get; private set; }

        public Cockpit()
        {
            Entries = new ObservableCollection<CockpitEntry>();
        }
    }
}
