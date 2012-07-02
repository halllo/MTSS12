using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    public class Distribution : IHistogram
    {
        Histogram histogram;

        public Distribution(IEnumerable<int> data)
        {
            histogram = new Histogram();
            InitializeBins(data);
            InitializeData(data);
        }

        private void InitializeBins(IEnumerable<int> data)
        {
            var maxValue = data.Max();
            for (int i = 0; i <= maxValue; i++)
                histogram.AddBucket(new Bucket(-0.5 + i, 0.5 + i));
        }
  
        private void InitializeData(IEnumerable<int> data)
        {
            histogram.AddData(data.Select(d => d * 1.0));
        }
  
        public int BinCount
        {
            get { return histogram.BucketCount; }
        }

        public double ElementsInBin(int index)
        {
            return histogram[index].Count;
        }
    }
}
