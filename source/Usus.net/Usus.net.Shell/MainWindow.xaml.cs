using System.Windows;

namespace andrena.Usus.net.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShellViewModel ViewModel;

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ShellViewModel();
            Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Cockpit.Hub = ViewModel.Hub;
            Hotspots.Hub = ViewModel.Hub;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AnalyzeClicked(this);
        }
    }
}
