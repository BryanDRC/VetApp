using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;
using VetApp.Services;

namespace VetApp.Controllers
{
	[FilterSecurity]
	[ResponseCache(NoStore = true, Duration = 0)]
	public class SupplierController : Controller
    {
        private readonly SupplierModel _supplier;
        public List<SupplierObj> _suppliersObject;
		ProductModel _productModel = new();
		public SupplierController()
        {
            _supplier = new SupplierModel();
            _suppliersObject = _supplier.GetSuppliers();

			

		}


        public IActionResult Supplier()
        {
            ViewBag.Suppliers = _suppliersObject;
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
        public JsonResult CreateSupplier(SupplierObj supplierObj)
        {

            var createSupplier = _supplier.CreateSupplier(supplierObj);
            return Json(createSupplier);
        }

        [HttpGet]
        public JsonResult GetSupplier(int idSupplier)
        {
            var user = _suppliersObject.Where(data => data.idSupplier == idSupplier).FirstOrDefault();
            return Json(user);
        }

        [HttpPut]
        public JsonResult UpdateSupplier(SupplierObj supplierObj)
        {
            var createSupplier = _supplier.UpdateSupplier(supplierObj);
            return Json(createSupplier);
        }

        [HttpDelete]
        public JsonResult DeleteSupplier(int idSupplier)
        {
            var supplier = _supplier.DeleteSupplier(idSupplier);
            return Json(supplier);
        }

		[HttpGet("Supplier/Supplier/{idSupplier}")]
		public async Task<IActionResult> Supplier(int idSupplier)
		{
			return View(await _productModel.GetProductsBySupplier(idSupplier));
		}

	}
}