namespace VetApp.Entities
{
	public class FormsObj
	{
		public int idMedicalRecord { get; set; }
		public int idUser { get; set; } = 0;
		public string doctorName { get; set; } = string.Empty;
		public string petName { get; set; } = string.Empty;
		public string petSpecies { get; set; } = string.Empty;
		public int clientIdCard { get; set; }
		public string motive { get; set; } = string.Empty;
		public DateTime arrival { get; set; }
		public DateTime attention { get; set; }
		public int idProduct { get; set; } = 0;
		public string product { get; set; } = string.Empty;
		public int idService { get; set; } = 0;
		public string servicName { get; set; } = string.Empty;
	}
}

