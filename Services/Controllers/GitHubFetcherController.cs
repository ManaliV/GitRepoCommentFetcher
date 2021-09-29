using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    public class GitHubFetcherController : Controller
    {
        [HttpGet("people/{id}")]
        public ActionResult<GithubRepo> Get(int id)
        {
            var person = db.People.Find(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
