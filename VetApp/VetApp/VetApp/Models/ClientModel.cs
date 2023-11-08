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
                string url = "http://localhost:7032/VetAppApi/api/Client/CreateClient";
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
                string url = "http://localhost:7032/VetAppApi/api/Client/GetClients";

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
                string url = "http://localhost:7032/VetAppApi/api/Client/UpdateClient";
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
                string url = "http://localhost:7032/VetAppApi/api/Client/DeleteClient?idClient=" + idClient;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }
    }
}