using System;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatingFunctionLimits
    {
        public Func<int, int> CyclomaticComplexity { get; set; }
        public Func<int, int> MethodLength { get; set; }
        public Func<int, int> ClassSize { get; set; }
        public Func<int, int> NumberOfNonStaticPublicFields { get; set; }
        public Func<int, int> CumulativeComponentDependency { get; set; }

        public RatingFunctionLimits()
        {
            CyclomaticComplexity = cs => 4;
            MethodLength = cs => 9;
            ClassSize = cs => 12;
            NumberOfNonStaticPublicFields = cs => 0;
            CumulativeComponentDependency = cs => (int)(cs * (1.5 / Math.Pow(2, (Math.Log(cs) / Math.Log(5)))));
        }
    }
}
