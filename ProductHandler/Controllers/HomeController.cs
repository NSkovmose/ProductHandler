using Microsoft.AspNetCore.Mvc;
using ProductHandler.Models;
using System.Diagnostics;

namespace ProductHandler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}