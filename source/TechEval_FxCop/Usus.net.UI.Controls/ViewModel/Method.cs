using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Usus.net.UI.Controls.ViewModel
{
    public class Method
    {
        public string Name { get; set; }
        public int Statements { get; set; }
        public int CyclomaticComplexity { get; set; }
        public string Callees { get; set; }
    }
}
