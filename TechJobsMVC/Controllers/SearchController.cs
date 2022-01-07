using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Search";

            if (searchType == "all")
            {
                ViewBag.Jobs = JobData.FindByValue(searchTerm);
            }
            else
            {
                ViewBag.Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            return View("~/Views/Search/Index.cshtml");

        }
    }
}
