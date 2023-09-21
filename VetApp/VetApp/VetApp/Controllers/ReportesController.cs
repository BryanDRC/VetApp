using Microsoft.AspNetCore.Mvc;

namespace VetApp.Controllers
{
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
