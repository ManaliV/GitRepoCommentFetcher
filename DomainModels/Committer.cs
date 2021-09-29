using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
    public class Committer
    {
        public string name { get; set; }
        public string email { get; set; }

        public DateTime date { get; set; }
    }
}
