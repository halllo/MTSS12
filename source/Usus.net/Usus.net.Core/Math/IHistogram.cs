using System.Collections.Generic;

namespace andrena.Usus.net.Core.Math
{
    public interface IHistogram
    {
        int BinCount { get; }
        double ElementsInBin(int index);
        IEnumerable<double> Data { get; }
        FittingReport Fitting { get; }
    }
}
