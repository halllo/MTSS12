using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;

namespace andrena.Usus.net.View.Dialogs.ViewModels
{
    public class NamespaceCycle
    {
        private readonly IEnumerable<NamespaceMetricsReport> namespaces;
        private readonly MetricsReport metrics;

        public NamespaceCycle(MetricsReport metrics, IEnumerable<NamespaceMetricsReport> namespaces)
        {
            this.metrics = metrics;
            this.namespaces = namespaces;
            Jump += type => { };
        }

        public event Action<TypeMetricsReport> Jump;

        public IEnumerable<string> Namespaces
        {
            get { return namespaces.Select(n => n.Name); }
        }

        public IEnumerable<string> TypesReferencingOutOf(string namespaceName)
        {
            var currentNamespace = metrics.ForNamespace(namespaceName);
            var otherNamespaceInCycle = namespaces.ExceptThis(currentNamespace).ToList();
            return from type in TypesReferencingOutOf(currentNamespace, to: otherNamespaceInCycle)
                   select type.FullName;
        }

        public void JumpTo(string type)
        {
            Jump(metrics.ForType(type));
        }

        private IEnumerable<TypeMetricsReport> TypesReferencingOutOf(NamespaceMetricsReport currentNamespace, IEnumerable<NamespaceMetricsReport> to)
        {
            return from type in metrics.TypesOfNamespace(currentNamespace)
                   where NamespacesOf(ReferencesOf(type)).Intersect(to).Any()
                   select type;
        }

        private IEnumerable<TypeMetricsReport> ReferencesOf(TypeMetricsReport type)
        {
            return from reference in type.InterestingDirectDependencies
                   select metrics.ForType(reference);
        }

        private IEnumerable<NamespaceMetricsReport> NamespacesOf(IEnumerable<TypeMetricsReport> types)
        {
            return from type in types
                   select metrics.ForNamespace(type.Namespaces.First());
        }
    }
}
