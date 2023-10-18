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

		public string RequestNewPasswordEmailSend(UserObj userObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(userObj);
				string url = "https://localhost:7032/api/Auth/RequestNewPasswordEmailSend";
				HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadAsStringAsync().Result;

				return String.Empty;
			}
		}
	}
}
