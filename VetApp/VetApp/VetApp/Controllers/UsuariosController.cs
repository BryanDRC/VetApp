using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Cliente()
        {
            return View();
        }
        
        public IActionResult AgregarCliente()
        {
            return View();
        }
       
    }
}
