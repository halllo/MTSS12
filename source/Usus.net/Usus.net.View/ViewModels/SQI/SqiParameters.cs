using System;
using andrena.Usus.net.Core.SQI;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SqiParameters : IParameterProvider
    {
        public event Action ParametersChanged;

        public SqiParameters()
        {
            ParametersChanged += () => { };
        }

        public SqiParameter Assign(string parameter, int value, Action<SqiParameters, int> valueAssignment)
        {
            valueAssignment(this, value);
            var sqiParameter = new SqiParameter(parameter) { Value = value.ToString() };
            sqiParameter.OnChange += newValue => SqiParameterConverter.Number(newValue, v =>
            {
                valueAssignment(this, v);
                ParametersChanged();
            });
            return sqiParameter;
        }

        public SqiParameter Assign(string parameter, double value, Action<SqiParameters, double> valueAssignment)
        {
            valueAssignment(this, value);
            var sqiParameter = new SqiParameter(parameter) { Value = value.ToString("0.00") };
            sqiParameter.OnChange += newValue => SqiParameterConverter.Percentage(newValue, v =>
            {
                valueAssignment(this, v);
                ParametersChanged();
            });
            return sqiParameter;
        }

        public double TestCoverage { get; set; }
        public int NamespaceCycles { get; set; }
        public int ComplicatedMethods { get; set; }
        public double AverageComponentDependency { get; set; }
        public int BigClasses { get; set; }
        public int BigMethods { get; set; }
        public int CompilerWarnings { get; set; }
        public int Namespaces { get; set; }
        public int Classes { get; set; }
        public int Methods { get; set; }
        public int Rloc { get; set; }
    }
}
