

namespace PoateAiciFunctioneaza.Domain
{
    public class Client : Entity<int>
    {
        public string nume { get; set; }
        public string nrTelefon { get; set; }

        public int Id { get; set; }
        public Client(int id, string nume, string nrTelefon)  
        {
            this.Id = id;
            this.nume = nume;
            this.nrTelefon = nrTelefon;
        }

        public override string ToString()
        {
          
            return string.Format("Client {0} {1} {2}", Id, nume, nrTelefon);



        }

    }
}