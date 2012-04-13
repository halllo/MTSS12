using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Usus.net.UI.Controls.ViewModel
{
    public class Event
    {
        public enum Of
        {
            build, save
        }

        public Event.Of Type { get; set; }
        public DateTime Time { get; set; }
    }
}
