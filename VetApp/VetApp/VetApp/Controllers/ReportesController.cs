using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class ReportesController : Controller
    {
		private readonly ReportsModel _reportsModel;
		private readonly IConfiguration _configuration;

		public ReportesController(IConfiguration configuration)
		{
			_configuration = configuration;
			_reportsModel = new ReportsModel(_configuration);

		}

		public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReporteCitas()
        {
            return View();
        }

		[HttpPost]
		public IActionResult ReporteCitas(string startDate, string endDate)
		{

			if(String.IsNullOrEmpty(startDate) || String.IsNullOrEmpty(startDate)){
				ViewBag.Message = "Debe de seleccionar la fecha de inicio y la fecha de fin del reporte.";
				return View();
			}

			ViewBag.AppointmentReport = _reportsModel.AppointmentsReport(startDate, endDate);
			
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
