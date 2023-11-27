using Newtonsoft.Json;
using VetApp.Entities;

namespace VetApp.Models
{
    public class FormsModel
    {
		private readonly IConfiguration _configuration;
		private string _urlApi;
		public FormsModel(IConfiguration configuration) 
        {
			_configuration = configuration;
			_urlApi = _configuration.GetSection("Claves:VetAppApiUrl").Value;
		}

        public int CreateForms(FormsObj formsObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(formsObj);
                string url = _urlApi + "api/Forms/CreateForms";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<FormsObj> GetFormss()
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Forms/GetFormss";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<FormsObj>>().Result;

                return new List<FormsObj>();
            }
        }


        public int UpdateForms(FormsObj formsObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(formsObj);
                string url = _urlApi + "api/Forms/UpdateForms";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteForms(int idForms)
        {
            using (var client = new HttpClient())
            {
                string url = _urlApi + "api/Forms/DeleteForms?idForms=" + idForms;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }



	}
}