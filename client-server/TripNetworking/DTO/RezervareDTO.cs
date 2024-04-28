using System;

namespace TripNetworking.DTO
{
    [Serializable]
    public class RezervareDTO
    {
        public string NumeClient { get; set; }
        public string TelefonClient { get; set; }
        public int ExcursieID { get; set; }
        public int NumarBilete { get; set; }
        
        public RezervareDTO(string numeClient, string telefonClient, int excursieId, int numarBilete)
        {
            NumeClient = numeClient;
            TelefonClient = telefonClient;
            ExcursieID = excursieId;
            NumarBilete = numarBilete;
        }
    }
}