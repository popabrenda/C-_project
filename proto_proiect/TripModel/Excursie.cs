using System;

namespace TripModel
{
    [Serializable]
    public class Excursie : Entitate<int>
    {
        public string ObiectivTuristic { get; set; }
        public FirmaTransport FirmaTransport { get; set; }
        public TimeSpan OraPlecarii { get; set; }
        public double Pret { get; set; }
        public int NumarLocuriTotale { get; set; }
    
        public Excursie(string obiectivTuristic, FirmaTransport firmaTransport, TimeSpan oraPlecarii, double pret, int numarLocuriTotale)
        {
            this.ObiectivTuristic = obiectivTuristic;
            this.FirmaTransport = firmaTransport;
            this.OraPlecarii = oraPlecarii;
            this.Pret = pret;
            this.NumarLocuriTotale = numarLocuriTotale;
        }
    
        public override string ToString()
        {
            return "Excursie{" +
                   "id=" + Id +
                   ", obiectivTuristic='" + ObiectivTuristic + '\'' +
                   ", firmaTransport=" + FirmaTransport +
                   ", oraPlecarii=" + OraPlecarii +
                   ", pret=" + Pret +
                   ", numarLocuriTotale=" + NumarLocuriTotale +
                   '}';
        }
    
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Excursie excursie = (Excursie) obj;
            return Id == excursie.Id;
        }
    }
}