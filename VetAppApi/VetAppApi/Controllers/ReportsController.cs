﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController : ControllerBase
	{
		private ReportsModel _reportsModel;

		public ReportsController(ReportsModel reportsModel)
		{
			_reportsModel = reportsModel;
		}

		[HttpGet]
		[Route("AppointmentsReport")]
		public ActionResult<IEnumerable<AppointmentObj>> AppointmentsReport(string startDate, string endDate)
		{
			return _reportsModel.AppointmentsReport(startDate,endDate).ToList();
		}
	}
}