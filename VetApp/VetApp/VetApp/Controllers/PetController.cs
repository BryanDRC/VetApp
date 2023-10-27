using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Linq;

namespace VetApp.Controllers
{
    public class PetController : Controller
    {
        private readonly PetModel _petModel;
        public List<PetObj> _petsList;

        public PetController()
        {
            _petModel = new PetModel();
            _petsList = _petModel.GetPets();
        }

        public IActionResult Pet()
        {
            ViewBag.Pets = _petsList;
            return View();
        }

        public IActionResult AgregarMascota()
        {
            return View();
        }

        public IActionResult Mascota()
        {
            return View();
        }

        public IActionResult EditarMascota()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreatePet(PetObj petObj)
        {
            var createPet = _petModel.CreatePet(petObj);
            return Json(createPet);
        }

        [HttpGet]
        public JsonResult GetPet(int idPet)
        {
            var pet = _petsList.Where(data => data.IdPet == idPet).FirstOrDefault();
            return Json(pet);
        }

        [HttpPut]
        public JsonResult UpdatePet(PetObj petObj)
        {
            var updatePet = _petModel.UpdatePet(petObj);
            return Json(updatePet);
        }

        [HttpDelete]
        public JsonResult DeletePet(int idPet)
        {
            var deletePet = _petModel.DeletePet(idPet);
            return Json(deletePet);
        }
    }
}
