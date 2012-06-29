﻿using System.Windows;

namespace andrena.Usus.net.Shell
{
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
            Distributions.Hub = ViewModel.Hub;
        }

        private void StartAnalysis(object sender, RoutedEventArgs e)
        {
            ViewModel.AnalyzeClicked(this);
        }
    }
}
