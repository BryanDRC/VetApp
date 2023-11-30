using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class FormsController : Controller
	{
		private readonly FormsModel _forms;
		private readonly EmployeeModel _user;
		private readonly ProductModel _product;
		private readonly ServiceModel _service;
		public List<FormsObj> _formsObject;
		public List<UserObj> _userObject;
		public List<ProductObj> _productObject;
		public List<ServiceObj> _serviceObject;
		private readonly IConfiguration _configuration;
		public FormsController(IConfiguration configuration)
		{
			_configuration = configuration;
			_forms = new FormsModel(configuration);
			_user = new EmployeeModel(configuration);
			_product = new ProductModel(configuration);
			_service = new ServiceModel(configuration);
			_formsObject = _forms.GetForms();
			_userObject = _user.GetUsers();
			_productObject = _product.GetProducts();
			_serviceObject = _service.GetServices();

		}

		public IActionResult Forms()
		{
			ViewBag.userM = _userObject;
			ViewBag.productM = _productObject;
			ViewBag.serviceM = _serviceObject;
			ViewBag.Forms = _formsObject;
			return View();
		}

		[HttpGet]
		public JsonResult GetForms(int idMedicalRecord)
		{
			var forms = _formsObject.Where(data => data.idMedicalRecord == idMedicalRecord).FirstOrDefault();
			return Json(forms);
		}

		[HttpPost]
		public JsonResult CreateForms(FormsObj formsObj)
		{
			var createForms = _forms.CreateForms(formsObj);
			return Json(createForms);
		}

		[HttpPut]
		public JsonResult UpdateForms(FormsObj formsObj)
		{
			var createForms = _forms.UpdateForms(formsObj);
			return Json(createForms);
		}

		[HttpDelete]
		public JsonResult DeleteClient(int idMedicalRecord)
		{
			var froms = _forms.DeleteForms(idMedicalRecord);
			return Json(froms);
		}

	}
}
