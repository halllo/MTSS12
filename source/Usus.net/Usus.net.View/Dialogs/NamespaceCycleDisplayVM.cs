using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.Dialogs
{
    public class NamespaceCycleDisplayVM
    {
        public string Header { get; private set; }
        public ObservableCollection<string> MainEntries{ get; private set; }
        public ObservableCollection<string> SubEntries { get; private set; }
        private Dictionary<string, IEnumerable<string>> entries;

        public NamespaceCycleDisplayVM(string header)
        {
            Header = header;
            MainEntries = new ObservableCollection<string>();
            SubEntries = new ObservableCollection<string>();
        }

        public void AddAll(Dictionary<string, IEnumerable<string>> entries)
        {
            this.entries = entries;
            if (entries != null)
                foreach (var entry in entries.Keys) MainEntries.Add(entry);
        }

        public void Select(string entry)
        {
                SubEntries.Clear();
                foreach (var subEntry in entries[entry])
                    SubEntries.Add(subEntry);
        }
    }
}