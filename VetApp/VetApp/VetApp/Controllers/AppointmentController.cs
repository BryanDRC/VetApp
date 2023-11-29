using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly EmployeeModel _employee;
        private readonly AppointmentModel _appointment;
        private readonly ClientModel _client;
        private readonly IConfiguration _configuration;
		public List<AppointmentObj>? _listAppointments;
		public AppointmentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _employee = new EmployeeModel(_configuration);
            _appointment = new AppointmentModel(_configuration);
            _client = new ClientModel(_configuration);
			_listAppointments = _appointment.GetAppointmentsByDay();


		}

		[HttpGet]
		[FilterSecurity]
        public IActionResult Appointment()
        {
            ViewBag.Doctors = _employee.GetDoctors();
            ViewBag.Clients = _client.GetClients();
            ViewBag.Appointments = _listAppointments;
            return View();
        }

        [HttpGet]
        [FilterSecurity]
        public JsonResult GetAppointment(int idDate)
        {
            var appointments = _listAppointments?.FirstOrDefault(data => data.IdDate == idDate);
            return Json(appointments);
        }

        [HttpPost]
        [FilterSecurity]
        public JsonResult ScheduleAppointment(AppointmentObj appointmentObj)
        {

            if (String.IsNullOrEmpty(appointmentObj.DateReason))
            {
                appointmentObj.DateReason = "";
            }

            var appointment = _appointment.ScheduleAppointment(appointmentObj);
            return Json(appointment);
        }

		[HttpPut]
		[FilterSecurity]
		public JsonResult UpdateAppointment(AppointmentObj appointmentObj)
		{

			if (String.IsNullOrEmpty(appointmentObj.DateReason))
			{
				appointmentObj.DateReason = "";
			}

			var appointment = _appointment.UpdateAppointment(appointmentObj);
			return Json(appointment);
		}

		[HttpDelete]
		[FilterSecurity]
		public JsonResult DeleteAppointment(int idDate)
		{

			var appointment = _appointment.DeleteAppointment(idDate);
			return Json(appointment);
		}
	}
}
