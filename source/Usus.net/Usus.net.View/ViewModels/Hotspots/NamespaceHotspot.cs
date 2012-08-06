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
            var listdisplay = new ListDisplay();
            listdisplay.ItemClicked += i => TypeJump.To(metrics, i as TypeMetricsReport, jumper);
            listdisplay.DataContext = FindCrossNamespaceTypes();
            listdisplay.Show();
        }

        private ListDisplay<TypeMetricsReport> FindCrossNamespaceTypes()
        {
            var crossNamespaceTypeList = new ListDisplay<TypeMetricsReport>("Cross Namespace Types of " + Report.Name);
            crossNamespaceTypeList.AddAll(CrossNamespaceTypes());
            return crossNamespaceTypeList;
        }

        private IEnumerable<TypeMetricsReport> CrossNamespaceTypes()
        {
            var otherNamespaceInCycle = Report.CyclicDependencies.Except(Report.Name.Return()).ToList();
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