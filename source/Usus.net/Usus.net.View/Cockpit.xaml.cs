using System.Windows.Controls;

namespace andrena.Usus.net.View
{
    public partial class Cockpit : UserControl
    {
        ViewModels.Cockpit ViewModel;

        public Cockpit()
        {
            InitializeComponent();
            DataContext = ViewModel = new ViewModels.Cockpit();

            this.Loaded += new System.Windows.RoutedEventHandler(Cockpit_Loaded);
        }

        void Cockpit_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Average Component Dependency", Average = 100 });
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Class Size", Average = 100 });
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Cyclomatic Complexity", Average = 100 });
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Method Length", Average = 100 });
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Number Of Non-Static Public Fields", Average = 100 });
            ViewModel.Entries.Add(new ViewModels.CockpitEntry { Metric = "Namespaces with Cycles", Average = 100 });
        }
    }
}
