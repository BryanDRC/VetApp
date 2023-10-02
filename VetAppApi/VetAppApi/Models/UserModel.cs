using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
    public class UserModel
    {
        private readonly IConfiguration _configuration;

        public UserModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateUser(UserObj userObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_CreateUsers",
                        new { userObj.IdRol
                        , userObj.UserName
                        , userObj.UserFirstLastName
                        , userObj.UserSecondLastName
                        , userObj.UserIdCard
                        , userObj.UserMail
                        , userObj.UserNickName
                        , userObj.UserPassword
                        , userObj.UserPhoneNumber
                        , userObj.UserPicture},
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public IEnumerable<UserObj> GetUsers()
        {
            
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<UserObj>("SP_GetUsers", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<UserObj>();
        }

        public int UpdateUser(UserObj userObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateUser",
                        new
                        {
                            userObj.IdUser
                        ,
                            userObj.IdRol
                        ,
                            userObj.UserMail
                        ,
                            userObj.UserNickName
                        ,
                            userObj.UserPassword
                        ,
                            userObj.UserPhoneNumber
                        ,
                            userObj.UserPicture
                        },
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }

        public int DeleteUser(int idUser)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteUser",
                        new
                        {
                            idUser
                        },
                        commandType: CommandType.StoredProcedure);

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return 0;
        }
    }
}
