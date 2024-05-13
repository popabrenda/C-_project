using System;

namespace TripModel
{
    [Serializable]
    public class FirmaTransport : Entitate<int>
    {
        public string Nume {get; set;}

        public FirmaTransport(string nume)
        {
            Nume = nume;
        }
    
        public override string ToString()
        {
            return "FirmaTransport{" +
                   "id=" + Id +
                   ", nume='" + Nume + '\'' +
                   '}';
        }
    
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            FirmaTransport firmaTransport = (FirmaTransport) obj;
            return Id == firmaTransport.Id;
        }
    }
}