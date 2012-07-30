
namespace andrena.Usus.net.View.ViewModels.Cockpit
{
    public class CockpitEntry : ViewModel
    {
        public string Metric { get; set; }

        private string _Average;
        public string Average
        {
            get { return _Average; }
            set
            {
                _Average = value;
                Changed(() => Average);
            }
        }

        private string _Total;
        public string Total
        {
            get { return _Total; }
            set
            {
                _Total = value;
                Changed(() => Total);
            }
        }

        private string _Hotspots;
        public string Hotspots
        {
            get { return _Hotspots; }
            set
            {
                _Hotspots = value;
                Changed(() => Hotspots);
            }
        }

        private string _Distribution;
        public string Distribution
        {
            get { return _Distribution; }
            set
            {
                _Distribution = value;
                Changed(() => Distribution);
            }
        }
    }
}
