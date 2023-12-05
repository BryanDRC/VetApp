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
                            formsObj.idUser,
                            formsObj.idPet,
                            formsObj.idClient,
                            formsObj.motive,
                            formsObj.arrival,
                            formsObj.attention,
                            formsObj.idProduct,
                            formsObj.idService,
                            formsObj.statusP
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

        public IEnumerable<FormsListObj> GetFormsForCurrentDay()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<FormsListObj>("SP_GetFormsForCurrentDay", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<FormsListObj>();
        }

        public IEnumerable<FormsListObj> GetForms()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<FormsListObj>("SP_GetForms", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<FormsListObj>();
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
                            formsObj.idMedicalRecord,
                            formsObj.idUser,
                            formsObj.idPet,
                            formsObj.idClient,
                            formsObj.motive,
                            formsObj.arrival,
                            formsObj.attention,
                            formsObj.idProduct,
                            formsObj.idService,
                            formsObj.statusP
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

        public int DeleteForms(int IdMedicalRecord)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_DeleteForms",
                        new
                        {
                            IdMedicalRecord
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