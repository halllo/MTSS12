using System.Windows.Media;

namespace andrena.Usus.net.View.ViewModels
{
    public class ValueInTimeToColorConverter : BindingConverter<ValueInTime, SolidColorBrush>
    {
        public ValueInTimeToColorConverter()
        {
            Default = Brushes.Black;
            Converter = value =>
            {
                if (value.GotHigher) return Brushes.Red;
                if (value.GotLower) return Brushes.Green;
                return Brushes.Black;
            };
        }
    }
}