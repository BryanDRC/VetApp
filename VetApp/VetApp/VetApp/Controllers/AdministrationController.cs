using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;

namespace VetApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly EmployeeModel _employee;
        public List<UserObj> _usersObject;
        public AdministrationController()
        {
            _employee = new EmployeeModel();
            _usersObject = _employee.GetUsers();

		}


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarEmpleado()
        {
            return View();
        }

        public IActionResult Employee()
        {
            ViewBag.Users = _usersObject;
            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUser(UserObj userObj)
        {

			if (String.IsNullOrEmpty(userObj.UserPicture))
			{
				userObj.UserPicture = "";

			}
			else
			{
				userObj.UserPicture = SaveImage.SaveImageBase64(userObj.UserPicture, userObj.UserIdCard.ToString());
			}

			var createUser = _employee.CreateUser(userObj);
            return Json(createUser);
        }

		[HttpGet]
		public JsonResult GetUser(int idUser)
		{
			var user = _usersObject.Where(data => data.IdUser == idUser).FirstOrDefault();
			return Json(user);
		}

		[HttpPut]
		public JsonResult UpdateUser(UserObj userObj)
		{
			if (String.IsNullOrEmpty(userObj.UserPassword))
			{
				userObj.UserPassword = "";

			}

			if (String.IsNullOrEmpty(userObj.UserPicture))
			{
                userObj.UserPicture = "";

			}
            else
            {
				userObj.UserPicture = SaveImage.SaveImageBase64(userObj.UserPicture, userObj.UserIdCard.ToString());
			}

			var createUser = _employee.UpdateUser(userObj);
			return Json(createUser);
		}

		[HttpDelete]
		public JsonResult DeleteUser(int idUser)
		{
			var user = _employee.DeleteUser(idUser);
			return Json(user);
		}

		[HttpGet]
		public JsonResult ValidateUserMailExist(string userMail)
		{
			var user = _employee.ValidateUserMailExist(userMail);
			return Json(user);
		}

		[HttpGet]
		public IActionResult UpdateUserPassword(string? email = null)
		{
			ViewBag.Email = email;
			return View();
		}

		[HttpPut]
		public JsonResult UpdateUserPassword(UserObj userObj)
		{
			var updateUserPassword = _employee.UpdateUserPassword(userObj);
			return Json(updateUserPassword);
		}
	}
}
