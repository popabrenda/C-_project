using System;

namespace TripModel
{
    [Serializable]
    public class Rezervare : Entitate<int>
    {
        public string NumeClient { get; set; }
        public string TelefonClient { get; set; }
        public Excursie Excursie { get; set; }
        public int NumarBilete { get; set; }

        public Rezervare(string numeClient, string telefonClient, Excursie excursie, int numarBilete)
        {
            this.NumeClient = numeClient;
            this.TelefonClient = telefonClient;
            this.Excursie = excursie;
            this.NumarBilete = numarBilete;
        }
    
        public override string ToString()
        {
            return "Rezervare{" +
                   "id=" + Id +
                   ", numeClient='" + NumeClient + '\'' +
                   ", telefonClient='" + TelefonClient + '\'' +
                   ", Excursie=" + Excursie +
                   ", numarBilete=" + NumarBilete +
                   '}';
        }
    
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Rezervare rezervare = (Rezervare) obj;
            return Id == rezervare.Id;
        }
    }
}