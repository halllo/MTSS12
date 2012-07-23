using System;
using System.Windows;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public static class SqiParameterConverter
    {
        public static void Number(string newValue, Action<int> valueAssignment)
        {
            try
            {
                var parsed = int.Parse(newValue);
                valueAssignment(parsed);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void Percentage(string newValue, Action<double> valueAssignment)
        {
            try
            {
                var parsed = double.Parse(newValue);
                valueAssignment(parsed);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid percentage!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
