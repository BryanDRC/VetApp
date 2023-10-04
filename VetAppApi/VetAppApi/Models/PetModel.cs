using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
    public class PetModel
    {
        private readonly IConfiguration _configuration;

        public PetModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreatePet(PetObj petObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_CreatePet",
                        new
                        {
                            petObj.petName,
                            petObj.petSpecies,
                            petObj.IdClient },
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

        public IEnumerable<PetObj> GetPets()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<PetObj>("SP_GetPets", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<PetObj>();
        }

        public int UpdatePet(PetObj petObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdatePet",
                        new
                        {
                            petObj.IdPet,
                            petObj.petName,
                            petObj.petSpecies,
                            petObj.IdClient
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

        public int DeletePet(int idPet)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeletePet",
                        new
                        {
                            idPet
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
