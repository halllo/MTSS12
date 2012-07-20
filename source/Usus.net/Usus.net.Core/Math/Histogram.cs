using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    public class Histogram
    {
        MathNet.Numerics.Statistics.Histogram histogram;
        List<double> data;

        public Histogram(IEnumerable<int> data)
        {
            this.data = data.ToList(d => d * 1.0);
            Initialize();
        }

        private void Initialize()
        {
            histogram = new MathNet.Numerics.Statistics.Histogram();
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

        public IEnumerable<double> Data
        {
            get { return data; }
        }
    }
}
