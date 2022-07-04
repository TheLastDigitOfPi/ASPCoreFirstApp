using ASPCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCoreFirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Message = "Debugging is a very useful tool in the 'rare situation' when your code doesn’t execute as you expected it would";
            //Ah yes, my code "Rarely" doesn't execute as I expected it would...
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}