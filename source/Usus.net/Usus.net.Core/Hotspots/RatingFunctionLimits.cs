using System;

namespace andrena.Usus.net.Core.Hotspots
{
    public class RatingFunctionLimits
    {
        public int CyclomaticComplexity { get; set; }
        public int MethodLength { get; set; }
        public int ClassSize { get; set; }
        public int NumberOfNonStaticPublicFields { get; set; }

        public RatingFunctionLimits()
        {
            CyclomaticComplexity = 4;
            MethodLength = 9;
            ClassSize = 12;
            NumberOfNonStaticPublicFields = 0;
        }
    }
}
