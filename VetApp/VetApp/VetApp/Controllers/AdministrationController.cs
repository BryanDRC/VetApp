using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;

namespace VetApp.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly EmployeeModel _employee;
        public AdministrationController()
        {
            _employee = new EmployeeModel();
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
            var users = _employee.GetUsers();
            ViewBag.Users = users;
            return View();
        }

        public IActionResult EditarEmpleado()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateUser(UserObj userObj)
        {
            userObj.UserPicture = "";

            if (userObj.UserPicture != null || userObj.UserPicture !="")
            {
                //userObj.UserPicture = SaveUserPicture(userObj.UserPicture);
            }

            var createUser = _employee.CreateUser(userObj);
            return Json(createUser);
        }
    }
}
