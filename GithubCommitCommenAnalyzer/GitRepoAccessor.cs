using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DomainModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Util;

namespace GithubCommitCommenAnalyzer.Controllers
{
    public class GitRepoAccessor
    {
        public GitRepoAccessor(string username, string accessToken, string repository)
        {
            _userName = username;
            _accessToken = accessToken;
            _repository = repository;
        }

        public async Task<List<CommitComment>> GetAllComments()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", _accessToken);

            using (var response = await client.GetAsync($"/repos/{_userName}/{_repository}/commits"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return StoreCommitCommentsInCircularList(apiResponse);
            }            
        }

        private List<CommitComment> StoreCommitCommentsInCircularList(string apiResponse)
        {
            List<CommitComment> commitList= new List<CommitComment>();
            CommitComment comment = new CommitComment();

            JArray array = JArray.Parse(apiResponse);
            foreach (var item in array.Children())
            {
                JObject eachCommit = JObject.Parse(item.ToString());

                string commentString = eachCommit["commit"]["message"].ToString();
                string[] commentWords = commentString.Split(' ');

                foreach (var word in commentWords)
                    comment.Comments = word.ToString();

                commitList.Add(comment);
            }

            return commitList;
            
        }

        private string _userName;
        private string _accessToken;
        private string _repository;
    }
}
