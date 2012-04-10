﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Usus.net.UI.Controls
{
    /// <summary>
    /// Interaction logic for SolutionView.xaml
    /// </summary>
    public partial class SolutionView : UserControl
    {
        Func<IEnumerable<string>> _getProjects;

        public SolutionView(Func<IEnumerable<string>> getProjects)
        {
            InitializeComponent();
            _getProjects = getProjects;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            projectList.ItemsSource = _getProjects();
        }
    }
}
