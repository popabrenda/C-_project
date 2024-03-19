namespace PoateAiciFunctioneaza.Domain
{
    public class Rezervare: Entity<int>
    {
        public Client client { get; set; }
        public Excursie excursie { get; set; }
        public int nrBilete { get; set; }
        public int Id { get; set; }
        
        public Rezervare(int id, Client client, Excursie excursie, int nrBilete) 
        {
            this.Id = id;
            this.client = client;
            this.excursie = excursie;
            this.nrBilete = nrBilete;
        }
        
        public override string ToString()
        {
            return string.Format("Rezervare {0} {1} {2} {3}", Id, client, excursie, nrBilete);
        }

    }
}