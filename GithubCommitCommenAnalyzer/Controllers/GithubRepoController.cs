using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GithubRepo model)
        {
            if(ModelState.IsValid)
            {
                TempData["model"] = JsonConvert.SerializeObject(model);
                return Redirect("/GithubRepo/CommentAnalysis");

            }
            return View();
        }

        public async Task<IActionResult> CommentAnalysis()
        {
            //Fetch 
            GithubRepo model= JsonConvert.DeserializeObject<GithubRepo>(TempData["model"].ToString());
           // GithubRepo model = TempData["model"] as GithubRepo;
            GitRepoAccessor gitRepoAccessor = new GitRepoAccessor(model.UserName, model.AccessToken, model.GithubURL);
            List<CommitComment> commentList = await gitRepoAccessor.GetAllComments();

            CommentAnalyzercs commentAnalyzer = new CommentAnalyzercs(commentList);
            Dictionary<string, int> frequencyCounter = commentAnalyzer.CountFrequency();

            //Sort using Bubble Sort
            var keyList = frequencyCounter.Keys.ToArray();
            BubbleSort<string> bubbleSort = new BubbleSort<string>();
            string[] sortedKeys = bubbleSort.Sort(keyList);

            Dictionary<string, int> sortedFrequencyCounter = new Dictionary<string, int>();
            foreach (var key in sortedKeys)
                sortedFrequencyCounter.Add(key, frequencyCounter[key]);

            var viewModel = new FrequencyCounterViewModel();
            viewModel.Values = sortedFrequencyCounter;

            return View(viewModel);
        }


        public IActionResult Export(Dictionary<string, string> stepsDictionary)
        {
            var newFile = @"c://newbook.core.xlsx";

            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new XSSFWorkbook();

                ISheet sheet1 = workbook.CreateSheet("Sheet1");
                                
                int rowIndex = 0;
                foreach(var key in stepsDictionary.Keys)
                {
                    IRow row = sheet1.CreateRow(rowIndex);
                    var wordCell = row.CreateCell(0);
                    var countCell = row.CreateCell(1);

                    wordCell.SetCellValue(key);
                    countCell.SetCellValue(stepsDictionary[key]);
                    ++rowIndex;
                }

                workbook.Write(fs);
            }

            return View();
        }






    }
}
