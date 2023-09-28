using VetApp.Entities;

namespace VetApp.Models
{
    public class AuthModel
    {
        public string? lblmsj { get; set; }

        public UserObj? Login(UserObj userObj)
        {
            using (var access = new HttpClient())
            {
                string urlApi = "https://localhost:7032/api/Auth/Login";
                JsonContent content = JsonContent.Create(userObj);
                HttpResponseMessage response = access.PostAsync(urlApi, content).GetAwaiter().GetResult();
                return (response.IsSuccessStatusCode) ? response.Content.ReadFromJsonAsync<UserObj>().Result : null;
            }
        }
    }
}
