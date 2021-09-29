using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubCommitCommenAnalyzer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GithubCommitCommenAnalyzer.Controllers
{
    public class GithubRepoController:Controller
    {
        private readonly ILogger<GithubRepoController> _logger;

        public GithubRepoController(ILogger<GithubRepoController> logger)
        {
            _logger = logger;
        }

        public IActionResult FetchRepo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>FetchRepo(GithubRepo model)
        {
            if(ModelState.IsValid)
            {





            }
            return View();
        }

        
    }
}
