using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class MascotasController : Controller
    {
        public IActionResult Mascotas()
        {
            return View();
        }
        
        public IActionResult AgregarMascota()
        {
            return View();
        }


    }
}
