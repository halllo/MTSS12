using System.Collections.Generic;
using MathNet.Numerics.Statistics;

namespace andrena.Usus.net.Core.Math
{
    // JH, 01.08.2012 - Everytime you have to write an extension method, the api is actually shit. 
    public static class HistogramExtensions
    {
        public static MathNet.Numerics.Statistics.Histogram AddBuckets(this MathNet.Numerics.Statistics.Histogram histogram, IEnumerable<Bucket> buckets)
        {
            foreach (var bucket in buckets)
            {
                histogram.AddBucket(bucket);
            }
            return histogram;
        }
    }
}