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
            InitializeBuckets();
            histogram.AddData(data);
        }

        private void InitializeBuckets()
        {
            foreach (var number in NumbersUpTo(MaxValueOf(data)))
                AddNewBucketFor(number);
        }

        private void AddNewBucketFor(int number)
        {
            histogram.AddBucket(new Bucket(-0.5 + number, 0.5 + number));
        }

        private static int MaxValueOf(IEnumerable<double> data)
        {
            return (int)data.Max() + 1;
        }

        private static IEnumerable<int> NumbersUpTo(int maxValue)
        {
            return Enumerable.Range(0, maxValue);
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
