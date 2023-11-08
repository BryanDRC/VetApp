using VetApp.Entities;

namespace VetApp.Models
{
    public class PetModel
    {
        public PetModel() { }

        public int CreatePet(PetObj petObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(petObj);
                string url = "http://localhost:7032/VetAppApi/api/Pet/CreatePet";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<PetObj> GetPets()
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:7032/VetAppApi/api/Pet/GetPets";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<PetObj>>().Result;

                return new List<PetObj>();
            }
        }

        public int UpdatePet(PetObj petObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(petObj);
                string url = "http://localhost:7032/VetAppApi/api/Pet/UpdatePet";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeletePet(int idPet)
        {
            using (var client = new HttpClient())
            {
                string url = "http://localhost:7032/VetAppApi/api/Pet/DeletePet?idPet=" + idPet;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }
    }
}
