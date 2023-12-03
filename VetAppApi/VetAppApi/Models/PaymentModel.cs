using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
    public class PaymentModel
    {
        private readonly IConfiguration _configuration;

        public PaymentModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<PaymentTypeObj> GetPaymentType()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<PaymentTypeObj>("SP_GetPaymentTypes", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<PaymentTypeObj>();
        }

        public IEnumerable<InvoicesObj> GetInvoices()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<InvoicesObj>("SP_GetAllInvoices", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<InvoicesObj>();
        }
        public int CreateInvoices(InvoicesObj invoices)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_InsertInvoice",
                        new
                        {
                            invoices.numReference,
                            invoices.dateInvoices,
                            invoices.totalCancel,
                            invoices.totalCanceled,
                            invoices.idPayment,
                            invoices.idClient
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


        public IEnumerable<DetailObj> GetDetail()
        {

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Query<DetailObj>("SP_GetDetail", null,
                        commandType: CommandType.StoredProcedure).ToList();

                    return datos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<DetailObj>();
        }

        public int CreateDetail(DetailObj detail)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
                {
                    var datos = connection.Execute("SP_InsertDetail",
                        new
                        {
                            detail.nameDetail,
                            detail.descriptionDetail,
                            detail.amountDetail,
                            detail.costDetail,
                            detail.idInvoices
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
