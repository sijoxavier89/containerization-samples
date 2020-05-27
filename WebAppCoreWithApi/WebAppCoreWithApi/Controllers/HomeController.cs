using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppCoreWithApi.Models;

namespace WebAppCoreWithApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // connecting to api service
            ApiService apis = new ApiService();
            var messageApi = apis.FindCatalogItem(1);
            ViewData["MessageApi"] = messageApi;
            return View();
        }

        public IActionResult About()
        {
            ApiService apis = new ApiService();
            var messageApi = apis.FindCatalogItem(1);
            ViewData["Message"] = messageApi;

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
