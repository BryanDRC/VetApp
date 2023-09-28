using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using VetApp.Entities;
using VetApp.Models;

namespace VetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly AuthModel _authModel = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() //mi login
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserObj userObj) 
        {
            try
            {
                var result = _authModel.Login(userObj);
                if (result != null)
                {
                    return RedirectToAction("Planilla", "Planilla");
                }
                else
                {
                    ViewBag.MsjError = "La información indicada es incorrecta.";
                    return View("Index");
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
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