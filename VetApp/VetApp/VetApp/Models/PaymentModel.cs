﻿using VetApp.Entities;

namespace VetApp.Models
{
    public class PaymentModel
    {
        private readonly IConfiguration _configuration;
        private string _urlApi;
        public PaymentModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
        }

        public List<PaymentTypeObj>? GetPaymentType()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetPaymentType";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<PaymentTypeObj>>().Result;

                return new List<PaymentTypeObj>();
            }
        }

        public int CreateInvoices(InvoicesObj invoicesObj)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/CreateInvoices";

                var data = JsonContent.Create(invoicesObj);

                HttpResponseMessage response = client.PostAsync(url,data).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<InvoicesObj>? GetInvoices()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetInvoices";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<InvoicesObj>>().Result;

                return new List<InvoicesObj>();
            }
        }

        public List<DetailInvoicesObj>? GetDetail()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Payment/GetDetail";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<DetailInvoicesObj>>().Result;

                return new List<DetailInvoicesObj>();
            }
        }
    }
}