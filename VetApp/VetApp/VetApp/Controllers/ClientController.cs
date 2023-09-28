using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;


namespace VetApp.Controllers
{
    public class ClientController : Controller
    {
        readonly ClientModel _clientModel = new();


        [HttpGet]
        public async Task<IActionResult> Client()
        {
            return View(await _clientModel.GetListClients());
        }



        [HttpGet]
        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterClient(ClientObj clientObj)
        {
            return _clientModel.RegisterClient(clientObj) != null
                ? RedirectToAction("Index", "Home") : View();
        }


        //[HttpPost]
        //public ActionResult UpdateClient(ClientObj clientObj)
        //{
        //    clientObj.PropertyCount = 2;
        //    clientObj.ProvincePhoto = "lorem.pgn";
        //    return _clientModel.UpdateClient(clientObj) != null
        //        ? RedirectToAction("Provinces", "Province") : View();
        //}
    }
}