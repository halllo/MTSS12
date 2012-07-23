using System;

namespace andrena.Usus.net.View.ViewModels.SQI
{
    public class SqiParameter
    {
        public SqiParameter(string parameter)
        {
            OnChange += _ => { };
            Parameter = parameter;
        }

        public string Parameter { get; private set; }

        private string _Value;
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                OnChange(_Value);
            }
        }

        public event Action<string> OnChange;
    }
}
