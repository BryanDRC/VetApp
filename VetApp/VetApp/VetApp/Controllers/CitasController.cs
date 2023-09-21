using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Citas()
        {
            return View();
        }
    }
}
