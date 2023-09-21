using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
    public class PlanillaController : Controller
    {
        public IActionResult Planilla()
        {
            return View();
        }
    }
}
