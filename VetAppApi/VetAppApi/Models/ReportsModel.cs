using System.Data.SqlClient;
using System.Data;
using VetAppApi.Entities;
using Dapper;

namespace VetAppApi.Models
{
	public class ReportsModel
	{
		private readonly IConfiguration _configuration;

		public ReportsModel(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IEnumerable<AppointmentObj> AppointmentsReport(string startDate, string endDate)
		{

			try
			{
				using (var connection = new SqlConnection(_configuration.GetConnectionString("Connection")))
				{
					var datos = connection.Query<AppointmentObj>("SP_AppointmentsReport", new
					{
						startDate,
						endDate
					},
						commandType: CommandType.StoredProcedure).ToList();

					return datos;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<AppointmentObj>();
		}
	}
}
