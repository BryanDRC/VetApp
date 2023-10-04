using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;

namespace VetApp.Controllers
{
	public class ClientController : Controller
	{
		private readonly ClientModel _client;
		public List<ClientObj> _clientsObject;
		public ClientController()
		{
			_client = new ClientModel();
			_clientsObject = _client.GetClients();

		}


		public IActionResult Client()
		{
			ViewBag.Clients= _clientsObject;
			return View();
		}

		public IActionResult AgregarEmpleado()
		{
			return View();
		}

		public IActionResult Employee()
		{
			
			return View();
		}

		public IActionResult EditarEmpleado()
		{
			return View();
		}

		[HttpPost]
		public JsonResult CreateClient(ClientObj clientObj)
		{

			var createClient = _client.CreateClient(clientObj);
			return Json(createClient);
		}

		[HttpGet]
		public JsonResult GetClient(int idClient)
		{
			var user = _clientsObject.Where(data => data.idClient == idClient).FirstOrDefault();
			return Json(user);
		}

		[HttpPut]
		public JsonResult UpdateClient(ClientObj clientObj)
		{
			var createClient = _client.UpdateClient(clientObj);
			return Json(createClient);
		}

		[HttpDelete]
		public JsonResult DeleteClient(int idClient)
		{
			var client = _client.DeleteClient(idClient);
			return Json(client);
		}

	}
}


//using Microsoft.AspNetCore.Mvc;
//using VetApp.Entities;
//using VetApp.Models;

//namespace VetApp.Controllers
//{
//    public class ClientController : Controller
//    {
//		readonly ClientModel _clientModel = new();
//		private readonly ClientModel _client;
//		public List<UserObj> _usersObject;
//		public ClientController()
//		{
//			_client= new ClientModel();
//			_usersObject = _client.GetClients();

//		}




//		public IActionResult Client()
//        {
//            var clients = _clientModel.GetClients();
//            ViewBag.Clients = clients;
//            return View();
//        }


//        //[HttpPost]
//        //public ActionResult RegisterClient(ClientObj clientObj)
//        //{
//        //    return _clientModel.RegisterClient(clientObj) != null
//        //        ? RedirectToAction("Client", "Client") : View();
//        //}

//        [HttpPost]
//        public JsonResult RegisterClient(ClientObj clientObj)
//        {

//            var createClient = _client.RegisterClient(clientObj);
//            return Json(createClient);
//        }



//		[HttpPost]
//        public ActionResult UpdateClient(ClientObj clientObj)
//        {

//            return _clientModel.UpdateClient(clientObj) != null
//                ? RedirectToAction("Client", "Client") : View();
//        }


//        [HttpDelete]
//        public JsonResult DeleteClient(int idClient)
//        {
//            var client = _clientModel.DeleteUser(idClient);
//            return Json(client);
//        }
//    }
//}
