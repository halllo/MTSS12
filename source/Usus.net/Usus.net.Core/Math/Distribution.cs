using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    public class Distribution : IHistogram
    {
        Histogram histogram;
        List<double> data;

        public Distribution(IEnumerable<int> data)
        {
            this.data = data.ToList(d => d * 1.0);
            histogram = new Histogram();
            InitializeBins();
            InitializeData();
        }

        private void InitializeBins()
        {
            var maxValue = data.Max();
            for (int i = 0; i <= maxValue; i++)
                histogram.AddBucket(new Bucket(-0.5 + i, 0.5 + i));
        }

        private void InitializeData()
        {
            histogram.AddData(data);
        }

        public int BinCount
        {
            get { return histogram.BucketCount; }
        }

        public double ElementsInBin(int index)
        {
            return histogram[index].Count;
        }

        public double Mean
        {
            get { return new DescriptiveStatistics(data).Mean; }
        }
    }
}
