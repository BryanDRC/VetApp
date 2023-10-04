using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;

namespace VetApp.Controllers
{
    public class PetController : Controller
    {
        private readonly PetModel _petModel;
        public List<PetObj> _petObject;
        public PetController()
        {
            _petModel = new PetModel();
            _petObject = _petModel.GetPets();

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarMascota()
        {
            return View();
        }

        public IActionResult Pet()
        {
            ViewBag.Pets = _petObject;
            return View();
        }

        public IActionResult EditarMascota()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreatePet(PetObj petObj)
        {

            if (String.IsNullOrEmpty(petObj.petName))
            {
                petObj.petName = "";

            }         

            var createPet = _petModel.CreatePet(petObj);
            return Json(createPet);
        }

        [HttpGet]
        public JsonResult GetPet(int idPet)
        {
            var pet = _petObject.Where(data => data.IdPet == idPet).FirstOrDefault();
            return Json(pet);
        }

        [HttpPut]
        public JsonResult UpdatePet(PetObj petObj)
        {
            if (String.IsNullOrEmpty(petObj.petName))
            {
                petObj.petName = "";

            }

            if (String.IsNullOrEmpty(petObj.petSpecies))
            {
                petObj.petSpecies = "";

            }

            var createPet = _petModel.UpdatePet(petObj);
            return Json(createPet);
        }

        [HttpDelete]
        public JsonResult DeletePet(int idPet)
        {
            var pet = _petModel.DeletePet(idPet);
            return Json(pet);
        }


    }
}
