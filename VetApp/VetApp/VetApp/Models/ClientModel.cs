using VetApp.Entities;

namespace VetApp.Models
{
	public class ClientModel
	{
		public ClientModel() { }

		public int CreateClient(ClientObj clientObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(clientObj);
				string url = "https://localhost:7032/api/Client/CreateClient";
				HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}

		public List<ClientObj> GetClients()
		{
			using (var client = new HttpClient())
			{
				string url = "https://localhost:7032/api/Client/GetClients";

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<List<ClientObj>>().Result;

				return new List<ClientObj>();
			}
		}


		public int UpdateClient(ClientObj clientObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(clientObj);
				string url = "https://localhost:7032/api/Client/UpdateClient";
				HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}

		public int DeleteClient(int idClient)
		{
			using (var client = new HttpClient())
			{
				string url = "https://localhost:7032/api/Client/DeleteClient?idClient=" + idClient;
				HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}
	}
}



//using VetApp.Entities;
//using Newtonsoft.Json;

//namespace VetApp.Models
//{
//    public class ClientModel
//    {
//        public string? lblmsj { get; set; }
//        public List<ClientObj> listClient = new();

//        //public async Task<List<ClientObj>> GetListClients()
//        //{
//        //    using (var access = new HttpClient())
//        //    {
//        //        HttpResponseMessage response = await access.GetAsync("https://localhost:7216/api/Client/GetClients");
//        //        string resultstr = await response.Content.ReadAsStringAsync();
//        //        List<ClientObj>? list = JsonConvert.DeserializeObject<List<ClientObj>>(resultstr);
//        //        return list ?? new List<ClientObj>();
//        //    }
//        //}

//        public List<ClientObj> GetClients()
//        {
//            using (var client = new HttpClient())
//            {
//                string url = "https://localhost:7032/api/Client/GetClients";

//                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<List<ClientObj>>().Result;

//                return new List<ClientObj>();
//            }
//        }

//        public int RegisterClient(ClientObj clientObj)
//        {
//            using (var client = new HttpClient())
//            {
//                JsonContent body = JsonContent.Create(clientObj);
//                string url = "https://localhost:7032/api/Client/RegisterClient";
//                    HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }




//        public int UpdateClient(ClientObj clientObj)
//        {
//            using (var client = new HttpClient())
//            {
//                JsonContent body = JsonContent.Create(clientObj);
//                string url = "https://localhost:7032/api/Client/UpdateClient";
//                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }

//        public int DeleteClient(int idClient)
//        {
//            using (var client = new HttpClient())
//            {
//                string url = "https://localhost:7032/api/Client/DeleteClient?idClient=" + idClient;
//                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

//                if (response.IsSuccessStatusCode)
//                    return response.Content.ReadFromJsonAsync<int>().Result;

//                return 0;
//            }
//        }


//    }
//}