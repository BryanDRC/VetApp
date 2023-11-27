namespace VetAppApi.Entities
{
    public class FormsObj
    {
        public int IdMedicalRecord { get; set; } = 0;
        public int IdUser { get; set; } = 0;
        public int IdPet { get; set; } = 0;
        public int IdClient { get; set; } = 0;
        public string Motive { get; set; } = string.Empty;
        public DateTime Appointment { get; set; } = DateTime.MinValue;
        public DateTime Arrival { get; set; } = DateTime.MinValue;
        public DateTime Attention { get; set; } = DateTime.MinValue;
        public int IdProduct { get; set; } = 0;
        public int IdService { get; set; } = 0;
    }
}
