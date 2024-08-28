using Microsoft.AspNetCore.Mvc;
using StripeWebApp.Models;
using System.Diagnostics;

namespace StripeWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor to initialize the HomeController with a logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method to return the Index view
        public IActionResult Index()
        {
            // Returns the view for the home page
            return View();
        }

        // Action method to return the Privacy view
        public IActionResult Privacy()
        {
            // Returns the view for the privacy policy page
            return View();
        }

        // Action method to return the Error view with detailed error information
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Creates an ErrorViewModel with the current request ID or trace identifier
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
