
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetApp.Entities;
using VetApp.Models;
using System.Drawing;
using System.Text;
using System.IO;


namespace VetApp.Controllers
{

    [ResponseCache(NoStore = true, Duration = 0)]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ServiceModel _service;
        public List<ServiceObj> _servicesObject;
        private readonly ProductModel _productModel;
        public List<ProductObj> _productsList;
        private readonly ClientModel _clientModel;
        public List<ClientObj> _clientList;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _service = new ServiceModel(configuration);
            _servicesObject = _service.GetServices();
            _productModel = new ProductModel(configuration);
            _productsList = _productModel.GetProducts();
            _clientModel = new ClientModel(configuration);
            _clientList = _clientModel.GetClients();

        }


        public IActionResult Payment()
        {

            ViewBag.Services = _servicesObject;
            ViewBag.Products = _productsList;
            ViewBag.Clients = _clientList;
            return View();
        }





    }
}









