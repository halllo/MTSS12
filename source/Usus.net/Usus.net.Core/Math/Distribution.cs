using System.Collections.Generic;

namespace andrena.Usus.net.Core.Math
{
    public class Distribution
    {
        public Histogram Histogram { get; private set; }
        public IFittingReport GeometricalFit { get; private set; }

        public Distribution(IEnumerable<int> data)
        {
            Histogram = new Histogram(data);
            GeometricalFit = new GeometricalDistributionFitting(Histogram);
        }
    }
}
