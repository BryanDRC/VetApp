using Newtonsoft.Json;
using VetApp.Entities;

namespace VetApp.Models
{
    public class ProductModel
    {
        public ProductModel() { }

        public int CreateProduct(ProductObj productObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(productObj);
                string url = "http://localhost:7032/VetAppApi/api/Product/CreateProduct";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<ProductObj> GetProducts()
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:7032/VetAppApi/api/Product/GetProducts";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<ProductObj>>().Result;

                return new List<ProductObj>();
            }
        }


        public int UpdateProduct(ProductObj productObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(productObj);
                string url = "http://localhost:7032/VetAppApi/api/Product/UpdateProduct";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteProduct(int idProduct)
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:7032/VetAppApi/api/Product/DeleteProduct?idProduct=" + idProduct;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

		public async Task<List<ProductObj>> GetProductsBySupplier(int idSupplier)
		{
			using (var access = new HttpClient())
			{
				HttpResponseMessage response = await access.GetAsync($"https://localhost:7216/api/Product/GetProductsBySupplier/{idSupplier}");
				string resultStr = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<ProductObj>>(resultStr) ?? new List<ProductObj>();
			}
		}

	}
}