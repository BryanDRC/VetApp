using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Inventario()
        {
            return View();
        }
        
        public IActionResult AgregarInventario()
        {
            return View();
        }
    }
}
