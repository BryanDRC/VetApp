using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using VetAppApi.Entities;

namespace VetAppApi.Models
{
    public class AuthModel
    {

        private readonly IConfiguration _configuration;

        public AuthModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public UserObj? Login(UserObj userObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<UserObj>("SP_LogIn",
                    new
                    {
                        userObj.UserNickName,
                        userObj.UserPassword
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
