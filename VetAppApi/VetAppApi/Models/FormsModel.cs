using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
    public class FormsModel
    {
        private readonly IConfiguration _configuration;

        public FormsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int CreateForms(FormsObj formsObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_CreateForms",
                        new
                        {
                            formsObj.IdUser,
                            formsObj.IdPet,
                            formsObj.IdClient,
                            formsObj.Motive,
                            formsObj.Appointment,
                            formsObj.Arrival,
                            formsObj.Attention,
                            formsObj.IdProduct,
                            formsObj.IdService
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

        public IEnumerable<FormsObj> GetForms()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<FormsObj>("SP_GetForms", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<FormsObj>();
        }

        public int UpdateForms(FormsObj formsObj)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_UpdateForms",
                        new
                        {
                            formsObj.IdMedicalRecord,
                            formsObj.IdUser,
                            formsObj.IdPet,
                            formsObj.IdClient,
                            formsObj.Motive,
                            formsObj.Appointment,
                            formsObj.Arrival,
                            formsObj.Attention,
                            formsObj.IdProduct,
                            formsObj.IdService
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

        public int DeleteForms(int idForms)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteForms",
                        new
                        {
                            idForms
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
