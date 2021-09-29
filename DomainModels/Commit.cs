using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace DomainModels
{
    public class Commit
    {
        public Author author { get; set; }
        public Committer committer{get;set;}
        public string message { get; set; }

        public Tree tree { get; set; }

        public string url { get; set; }

        public string comment_count { get; set; }

        
    }
}
