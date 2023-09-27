using VetAppApi.Entities;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace VetAppApi.Models
{
    public class ClientModel
    {
        private readonly IConfiguration _configuration;

        public ClientModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int RegisterClient(ClientObj clientObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_RegisterClient",
                    new
                    {
                        clientObj.clientName,
                        clientObj.clientFirstLastName,
                        clientObj.clientSecondLastName,
                        clientObj.clientIdCard,
                        clientObj.clientPhoneNumber,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ClientObj> GetListClients()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Query<ClientObj>("SP_GetClients", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int DeleteClient(ClientObj clientObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_DeleteClient",
                    new
                    {
                        clientObj.idClient
                    }, commandType: CommandType.StoredProcedure);
            }
        }


        public int PutClient(ClientObj clientObj)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
            {
                return connection.Execute("SP_UpdateClient", new
                {
                    clientObj.clientName,
                    clientObj.clientFirstLastName,
                    clientObj.clientSecondLastName,
                    clientObj.clientIdCard,
                    clientObj.clientPhoneNumber,
                }, commandType: CommandType.StoredProcedure);
            }

        }

    }
}