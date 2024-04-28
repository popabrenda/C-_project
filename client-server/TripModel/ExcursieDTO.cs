using System;

namespace TripModel
{
    [Serializable]
    public class ExcursieDTO
    {
        public int Id { get; set; }
        public String ObiectivTuristic { get; set; }
        public string FirmaTransport { get; set; }
        public TimeSpan OraPlecarii { get; set; }
        public double Pret { get; set; }
        public int NumarLocuriDisponibile { get; set; }

        public ExcursieDTO(int id, string obiectivTuristic, string firmaTransport, TimeSpan oraPlecarii,
            double pret, int numarLocuriDisponibile)
        {
            this.Id = id;
            this.ObiectivTuristic = obiectivTuristic;
            this.FirmaTransport = firmaTransport;
            this.OraPlecarii = oraPlecarii;
            this.Pret = pret;
            this.NumarLocuriDisponibile = numarLocuriDisponibile;
        }
        public ExcursieDTO()
        {
        }
    }
}