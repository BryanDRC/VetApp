namespace VetApp.Entities
{
    public class PetObj
    {
        public int IdPet { get; set; } = 0;
        public string petName { get; set; } = string.Empty;
        public string petSpecies { get; set; } = string.Empty;
        public string clientName { get; set; } = string.Empty;
        public int IdClient { get; set; } = 0;
        
    }
}