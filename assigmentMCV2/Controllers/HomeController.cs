using assigmentMVC2.Models;
using assigmentMVC2.Models.Repos;
using assigmentMVC2.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace assigmentMVC2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPeopleService _peopleService;
        public HomeController()
        {
            _peopleService = new PeopleService(new PeopleRepo());
        }

        public IActionResult Index()
        {
            return View(_peopleService.LastAdded());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}