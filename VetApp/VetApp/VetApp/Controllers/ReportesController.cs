using Microsoft.AspNetCore.Mvc;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ReportesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReporteCitas()
        {
            return View();
        }

        public IActionResult ReportePlanilla()
        {
            return View();
        }

        public IActionResult ReporteTransacciones()
        {
            return View();
        }
    }
}
