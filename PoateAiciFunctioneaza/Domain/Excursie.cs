namespace PoateAiciFunctioneaza.Domain
{
    public class Excursie : Entity<int>
    {
        public string obiectiv { get; set; }
        public string firmaTransport { get; set; }
        public int oraPlecare { get; set; }
        public int pret { get; set; }
        public int locuriDisponibile { get; set; }
        public int Id { get; set; }
        
        public Excursie(int id, string obiectiv, string firmaTransport, int oraPlecare, int pret, int locuriDisponibile) 
        {
            this.Id = id;
            this.obiectiv = obiectiv;
            this.firmaTransport = firmaTransport;
            this.oraPlecare = oraPlecare;
            this.pret = pret;
            this.locuriDisponibile = locuriDisponibile;
        }
        
        public override string ToString()
        {
            return string.Format("Excursie {0} {1} {2} {3} {4} {5}", Id, obiectiv, firmaTransport, oraPlecare, pret, locuriDisponibile);
        }
        
    }
}