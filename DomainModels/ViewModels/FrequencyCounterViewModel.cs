using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ViewModels
{
    public class FrequencyCounterViewModel
    {
        public FrequencyCounterViewModel()
        {
            Values = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Values { get; set; }
    }
}
