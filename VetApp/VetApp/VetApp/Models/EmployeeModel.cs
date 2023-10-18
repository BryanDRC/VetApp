using VetApp.Entities;

namespace VetApp.Models
{
    public class EmployeeModel
    {
        public EmployeeModel() { }

        public int CreateUser(UserObj userObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(userObj);
                string url = "https://localhost:7032/api/User/CreateUser";
                HttpResponseMessage response = client.PostAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public List<UserObj> GetUsers()
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:7032/api/User/GetUsers";

                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<List<UserObj>>().Result;

                return new List<UserObj>();
            }
        }

        public int UpdateUser(UserObj userObj)
        {
            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(userObj);
                string url = "https://localhost:7032/api/User/UpdateUser";
                HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

        public int DeleteUser(int idUser)
        {
            using (var client = new HttpClient())
            {
                string url = "https://localhost:7032/api/User/DeleteUser?idUser=" + idUser;
                HttpResponseMessage response = client.DeleteAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadFromJsonAsync<int>().Result;

                return 0;
            }
        }

		public UserObj? ValidateUserMailExist(string userMail)
		{
			using (var client = new HttpClient())
			{
				string url = "https://localhost:7032/api/User/ValidateUserMailExist?email="+userMail;

				HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<UserObj>().Result;

				return null;
			}
		}

		public int UpdateUserPassword(UserObj userObj)
		{
			using (var client = new HttpClient())
			{
				JsonContent body = JsonContent.Create(userObj);
				string url = "https://localhost:7032/api/User/UpdateUserPassword";
				HttpResponseMessage response = client.PutAsync(url, body).GetAwaiter().GetResult();

				if (response.IsSuccessStatusCode)
					return response.Content.ReadFromJsonAsync<int>().Result;

				return 0;
			}
		}
	}
}
