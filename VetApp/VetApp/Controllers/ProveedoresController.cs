using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Proveedores()
        {
            return View();
        }

        public IActionResult AgregarProveedores()
        {
            return View();
        }
    }
}
