using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private PaymentModel _paymentModel;
        public PaymentController(PaymentModel paymentModel)
        {
            _paymentModel = paymentModel;
        }

        [HttpGet]
        [Route("GetPaymentType")]
        public ActionResult<IEnumerable<PaymentTypeObj>> GetPaymentType()
        {
            return _paymentModel.GetPaymentType().ToList();
        }

        [HttpGet]
        [Route("GetInvoices")]
        public ActionResult<IEnumerable<InvoicesObj>> GetInvoices()
        {
            return _paymentModel.GetInvoices().ToList();
        }

        [HttpPost]
        [Route("CreateInvoices")]
        public ActionResult<int> CreateIncoices(InvoicesObj invoices)
        {
            return _paymentModel.CreateInvoices(invoices);
        }

        [HttpGet]
        [Route("GetDetail")]
        public ActionResult<IEnumerable<DetailObj>> GetDetails()
        {
            return _paymentModel.GetDetail().ToList();
        }

        [HttpPost]
        [Route("CreateDetail")]
        public ActionResult<int> CreateDetail(DetailObj detail)
        {
            return _paymentModel.CreateDetail(detail);
        }
    }
}
