using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;

namespace VetApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductModel _product;
        public List<ProductObj> _productsObject;
        public ProductController()
        {
            _product = new ProductModel();
            _productsObject = _product.GetProducts();

        }


        //public IActionResult Product()
        //{
        //    ViewBag.Products = _productsObject;
        //    return View();
        //}


        [HttpPost]
        public JsonResult CreateProduct(ProductObj productObj)
        {

            var createProduct = _product.CreateProduct(productObj);
            return Json(createProduct);
        }

        [HttpGet]
        public JsonResult GetProduct(int idProduct)
        {
            var list = _productsObject.Where(data => data.idProduct == idProduct).FirstOrDefault();
            return Json(list);
        }

        [HttpPut]
        public JsonResult UpdateProduct(ProductObj productObj)
        {
            var createProduct = _product.UpdateProduct(productObj);
            return Json(createProduct);
        }

        [HttpDelete]
        public JsonResult DeleteProduct(int idProduct)
        {
            var product = _product.DeleteProduct(idProduct);
            return Json(product);
        }

    }
}