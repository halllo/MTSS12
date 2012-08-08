using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.Dialogs;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class NamespaceHotspot : Hotspot<NamespaceMetricsReport>
    {
        MetricsReport metrics;

        public NamespaceHotspot(NamespaceMetricsReport namespaceReport, MetricsReport metrics)
            : base(namespaceReport)
        {
            this.metrics = metrics;
        }

        public override void OnDoubleClick(IJumpToSource jumper)
        {
            var cycleDisplay = new NamespaceCycleDisplay();
            var viewModel = new NamespaceCycleDisplayVM("Namespace cycle");
            viewModel.AddAll(FindCrossNamespaceTypes());
            cycleDisplay.DataContext = viewModel;
            //listdisplay.ItemClicked += i => TypeJump.To(metrics, i as TypeMetricsReport, jumper);
            cycleDisplay.Show();
        }

        private Dictionary<string, IEnumerable<string>> FindCrossNamespaceTypes()
        {
            var cycle = new Dictionary<string, IEnumerable<string>>();
            foreach (var namespaceName in Report.CyclicDependencies)
                cycle.Add(namespaceName, ListOfTypesReferencingOutOf(namespaceName));
            return cycle;
        }

        private IEnumerable<string> ListOfTypesReferencingOutOf(string namespaceName)
        {
            return TypesReferncingOutOf(namespaceName).Select(n => n.FullName);
        }

        private IEnumerable<TypeMetricsReport> TypesReferncingOutOf(string namespaceName)
        {
            var otherNamespaceInCycle = Report.CyclicDependencies.Except(namespaceName.Return()).ToList();
            return from type in metrics.TypesOfNamespace(Report)
                   where NamespaceReferencesOf(type).Intersect(otherNamespaceInCycle).Any()
                   select type;
        }

        private static IEnumerable<string> NamespaceReferencesOf(TypeMetricsReport type)
        {
            return type.InterestingDirectDependencies.Select(n => n.Substring(0, n.LastIndexOf(".")));
        }
    }
}