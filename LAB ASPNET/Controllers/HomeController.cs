using System.Diagnostics;
using LAB_ASPNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace LAB_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromQuery] string name, [FromQuery] int? age, [FromQuery] bool? hasDrivingLicence)
        {
            string username = string.IsNullOrEmpty(name) ? "Stranger" : name;
            int userAge = age ?? 0;
            bool userHasDrivingLicence = hasDrivingLicence ?? false;

            ViewData["User"] = username;
            ViewData["Age"] = userAge;
            ViewData["HasDrivingLicence"] = userHasDrivingLicence;

            //zmiany testy
            if (userAge < 18)
            {
                return View("Under");
            }
            else
            {
                return View("Above");
            }
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
