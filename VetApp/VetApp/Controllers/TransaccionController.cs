using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class TransaccionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult CierreCaja()
        {
            return View();
        }

        public IActionResult Cobro()
        {
            return View();
        }
    }
}
