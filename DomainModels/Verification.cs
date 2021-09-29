using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class Verification
    {
        public bool verified { get; set; }
        public string reason { get; set; }
        public string signature { get; set; }

        public string payload { get; set; }
    }
}
