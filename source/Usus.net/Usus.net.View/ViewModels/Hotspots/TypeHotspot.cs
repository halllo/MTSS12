using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using andrena.Usus.net.View.ExtensionPoints;

namespace andrena.Usus.net.View.ViewModels.Hotspots
{
    public class TypeHotspot : Hotspot<TypeMetricsReport>
    {
        MetricsReport metrics;

        public TypeHotspot(TypeMetricsReport type, MetricsReport metrics)
            : base(type)
        {
            this.metrics = metrics;
        }

        public override void OnDoubleClick(IJumpToSource jumper)
        {
            var firstMethod = FirstMethodInType();
            if (HasJumpableLocation(firstMethod))
                JumpToMethod(jumper, firstMethod);
        }

        private void JumpToMethod(IJumpToSource jumper, MethodMetricsReport firstMethod)
        {
            jumper.JumpToFileLocation(
                firstMethod.SourceLocation.Filename,
                firstMethod.SourceLocation.Line, true);
        }

        private bool HasJumpableLocation(MethodMetricsReport firstMethod)
        {
            return firstMethod != null && firstMethod.SourceLocation.IsAvailable;
        }

        private MethodMetricsReport FirstMethodInType()
        {
            return AllJumpableMethods().WithMin(m => m.SourceLocation.Line);
        }

        private IEnumerable<MethodMetricsReport> AllJumpableMethods()
        {
            return from method in metrics.MethodsOfType(Report)
                   where method.SourceLocation.IsAvailable
                   select method;
        }
    }
}
