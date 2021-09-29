using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utility;

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
                //Fetch 
                GitRepoAccessor gitRepoAccessor = new GitRepoAccessor(model.UserName, model.AccessToken, model.GithubURL);
                List<CommitComment> commentList=await gitRepoAccessor.GetAllComments();

                CommentAnalyzercs commentAnalyzer = new CommentAnalyzercs(commentList);
                Dictionary<string,int>frequencyCounter= commentAnalyzer.CountFrequency();

                //Sort using Bubble Sort
                

            }
            return View();
        }



        
    }
}
