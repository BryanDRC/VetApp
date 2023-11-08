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
		private readonly IConfiguration _configuration;
		private readonly ProductModel _product;
        public List<ProductObj> _productsObject;
        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            _product = new ProductModel(configuration);
            _productsObject = _product.GetProducts();

        }




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