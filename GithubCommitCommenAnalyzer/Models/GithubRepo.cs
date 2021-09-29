using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GithubCommitCommenAnalyzer.Models
{
    public class GithubRepo
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string AccessToken { get; set; }

        [Required]         
        public string GithubURL { get; set; }

    }
}
