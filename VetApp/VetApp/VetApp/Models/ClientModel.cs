using Newtonsoft.Json;
using VetApp.Entities;


namespace VetApp.Models
{
    public class ClientModel
    {

        public async Task<string> RegisterClient(ClientObj clientObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Client/RegisterClient";
                JsonContent content = JsonContent.Create(clientObj);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }

        public async Task<List<ClientObj>> GetListClients()
        {
            using (var access = new HttpClient())
            {
                HttpResponseMessage response = await access.GetAsync("https://localhost:7216/api/Client/GetAllClients");
                string resultstr = await response.Content.ReadAsStringAsync();
                List<ClientObj>? list = JsonConvert.DeserializeObject<List<ClientObj>>(resultstr);
                return list ?? new List<ClientObj>();
            }
        }

        public async Task<string> DeleteClient(int idClient)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Client/DeleteClient";
                JsonContent content = JsonContent.Create(idClient);
                HttpResponseMessage response = await access.PostAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "OK" : string.Empty;
            }
        }

        public async Task<string> UpdateClient(ClientObj clientObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7216/api/Client/UpdateClient";
                JsonContent content = JsonContent.Create(clientObj);
                HttpResponseMessage response = await access.PutAsync(urlApi, content);
                return response.IsSuccessStatusCode ? "Ok" : string.Empty;
            }
        }

    }
}