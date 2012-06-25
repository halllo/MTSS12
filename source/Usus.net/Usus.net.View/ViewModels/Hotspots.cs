using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using andrena.Usus.net.Core.Hotspots;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.ViewModels
{
    public class Hotspots : AnalysisAwareViewModel
    {
        public ObservableCollection<HotspotClassSize> ClassSizes { get; private set; }
        public ObservableCollection<HotspotCumulativeComponentDependency> CumulativeComponentDependencies { get; private set; }
        public ObservableCollection<HotspotCyclomaticComplexity> CyclomaticComplexities { get; set; }
        public ObservableCollection<HotspotMethodLength> MethodLengths { get; private set; }
        public ObservableCollection<HotspotNamespaceInCycle> NamespacesInCycle { get; set; }
        public ObservableCollection<HotspotNonStaticPublicFields> NonStaticPublicFields { get; set; }
        
        public Hotspots()
        {
            ClassSizes = new ObservableCollection<HotspotClassSize>();
            CumulativeComponentDependencies = new ObservableCollection<HotspotCumulativeComponentDependency>();
            CyclomaticComplexities = new ObservableCollection<HotspotCyclomaticComplexity>();
            MethodLengths = new ObservableCollection<HotspotMethodLength>();
            NamespacesInCycle = new ObservableCollection<HotspotNamespaceInCycle>();
            NonStaticPublicFields = new ObservableCollection<HotspotNonStaticPublicFields>();
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

        protected override void AnalysisFinished(MetricsReport metrics)
        {
            var hotspots = metrics.Hotspots();
            Dispatch(() => SetClassSizes(hotspots.OfClassSize()));
            Dispatch(() => SetCumulativeComponentDependencies(hotspots.OfCumulativeComponentDependency()));
            Dispatch(() => SetCyclomaticComplexities(hotspots.OfCyclomaticComplexity()));
            Dispatch(() => SetMethodLengths(hotspots.OfMethodLength()));
            Dispatch(() => SetNamespacesInCycle(hotspots.OfNamespacesInCycle()));
            Dispatch(() => SetNonStaticPublicFields(hotspots.OfNumberOfNonStaticPublicFields()));
        }

        private void SetHotspots<T, S>(ObservableCollection<T> target, IEnumerable<S> source, Func<S, T> constructor)
        {
            foreach (var metrics in source) target.Add(constructor(metrics));
        }

        private void SetClassSizes(IEnumerable<TypeMetricsReport> classSizes)
        {
            SetHotspots(ClassSizes, classSizes, m => new HotspotClassSize
            {
                Size = m.NumberOfMethods,
                Class = m.Name,
                Fullname = m.FullName
            });
        }

        private void SetCumulativeComponentDependencies(IEnumerable<TypeMetricsReport> cumulativeComponentDependencies)
        {
            SetHotspots(CumulativeComponentDependencies, cumulativeComponentDependencies, m => new HotspotCumulativeComponentDependency
            {
                Dependencies = m.CumulativeComponentDependency,
                Class = m.Name,
                Fullname = m.FullName
            });
        }

        private void SetCyclomaticComplexities(IEnumerable<MethodMetricsReport> cyclomaticComplexities)
        {
            SetHotspots(CyclomaticComplexities, cyclomaticComplexities, m => new HotspotCyclomaticComplexity
            {
                Complexity = m.CyclomaticComplexity,
                Method = m.Name,
                Signature = m.Signature
            });
        }

        private void SetMethodLengths(IEnumerable<MethodMetricsReport> methodLengths)
        {
            SetHotspots(MethodLengths, methodLengths, m => new HotspotMethodLength
            {
                Length = m.MethodLength,
                Method = m.Name,
                Signature = m.Signature
            });
        }

        private void SetNamespacesInCycle(IEnumerable<NamespaceMetricsReport> namespacesInCycle)
        {
            SetHotspots(NamespacesInCycle, namespacesInCycle, m => new HotspotNamespaceInCycle
            {
                CycleSize = m.NumberOfNamespacesInCycle,
                Namespace = m.Name
            });
        }

        private void SetNonStaticPublicFields(IEnumerable<TypeMetricsReport> nonStaticPublicFields)
        {
            SetHotspots(NonStaticPublicFields, nonStaticPublicFields, m => new HotspotNonStaticPublicFields
            {
                Number = m.NumberOfNonStaticPublicFields,
                Class = m.Name,
                Fullname = m.FullName
            });
        }
    }
}
