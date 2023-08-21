using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class AdministracionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AgregarEmpleado()
        {
            return View();
        }
        
        public IActionResult Empleado()
        {
            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }
    }
}
