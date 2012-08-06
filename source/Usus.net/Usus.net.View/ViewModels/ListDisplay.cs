﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace andrena.Usus.net.View.ViewModels
{
    public class ListDisplay<T> : ViewModel
    {
        public string Header { get; private set; }
        public ObservableCollection<T> Entries { get; set; }
        
        public ListDisplay(string header)
        {
            Header = header;
            Entries = new ObservableCollection<T>();
        }

        public void AddEntries(IEnumerable<T> entries)
        {
            if (entries != null)
                foreach (var entry in entries) Entries.Add(entry);
        }
    }
}
