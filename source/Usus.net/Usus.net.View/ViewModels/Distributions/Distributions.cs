using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Math;

namespace andrena.Usus.net.View.ViewModels.Distributions
{
    public class Distributions : AnalysisAwareViewModel
    {
        public ObservableCollection<KeyValuePair<double, double>> ClassSizes { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> CumulativeComponentDependencies { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> CyclomaticComplexities { get; set; }
        public ObservableCollection<KeyValuePair<double, double>> MethodLengths { get; private set; }
        public ObservableCollection<KeyValuePair<double, double>> NamespacesInCycle { get; set; }
        public ObservableCollection<KeyValuePair<double, double>> NonStaticPublicFields { get; set; }

        public Distributions()
        {
            ClassSizes = new ObservableCollection<KeyValuePair<double, double>>();
            CumulativeComponentDependencies = new ObservableCollection<KeyValuePair<double, double>>();
            CyclomaticComplexities = new ObservableCollection<KeyValuePair<double, double>>();
            MethodLengths = new ObservableCollection<KeyValuePair<double, double>>();
            NamespacesInCycle = new ObservableCollection<KeyValuePair<double, double>>();
            NonStaticPublicFields = new ObservableCollection<KeyValuePair<double, double>>();
        }

        protected override void AnalysisStarted()
        {
            ClassSizes.Clear();
            CumulativeComponentDependencies.Clear();
            CyclomaticComplexities.Clear();
            MethodLengths.Clear();
            NamespacesInCycle.Clear();
            NonStaticPublicFields.Clear();
        }

        protected override void AnalysisFinished(Core.Reports.MetricsReport metrics)
        {
            Histogram(ClassSizes, metrics.TypeDistribution(t => t.ClassSize));
            Histogram(CumulativeComponentDependencies, metrics.TypeDistribution(t => t.CumulativeComponentDependency));
            Histogram(CyclomaticComplexities, metrics.MethodDistribution(m => m.CyclomaticComplexity));
            Histogram(MethodLengths, metrics.MethodDistribution(m => m.MethodLength));
            Histogram(NamespacesInCycle, metrics.NamespaceDistribution(n => n.NumberOfNamespacesInCycle));
            Histogram(NonStaticPublicFields, metrics.TypeDistribution(t => t.NumberOfNonStaticPublicFields));
        }

        private void Histogram(ObservableCollection<KeyValuePair<double, double>> target, IHistogram histogram)
        {
            Dispatch(() =>
            {
                for (int i = 0; i < Math.Min(50, histogram.BinCount); i++)
                    target.Add(new KeyValuePair<double, double>(i, histogram.ElementsInBin(i)));
            });
        }
    }
}
