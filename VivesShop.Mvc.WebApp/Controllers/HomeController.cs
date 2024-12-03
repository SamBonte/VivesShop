using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VivesShop.Mvc.WebApp.Core;
using VivesShop.Mvc.WebApp.Models;

namespace VivesShop.Mvc.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly VivesShopDbContext _vivesShopDbContext;
        public HomeController(VivesShopDbContext vivesShopDbContext)
        {
            _vivesShopDbContext = vivesShopDbContext;
        }

        public IActionResult Index()
        {
            var products = _vivesShopDbContext.Products.ToList();
            return View(products);
        }

        public IActionResult ManageShopItems()
        {
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
