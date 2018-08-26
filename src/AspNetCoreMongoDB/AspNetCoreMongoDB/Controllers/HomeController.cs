using AspNetCoreMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreMongoDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Search(String q)
        {
            ViewData["Message"] = "Search page.";
            var da = new DataAccess();
            ViewData["Count"] = da.CountCustomers();

            return !String.IsNullOrEmpty(q) ? View(da.GetCustomers(q)) : View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
