using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class PlanillaController : Controller
    {
        public IActionResult Planilla()
        {
            return View();
        }
    }
}
