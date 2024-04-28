

namespace PoateAiciFunctioneaza.Domain
{
    public class Client : Entity<int>
    {
        public string nume { get; set; }
        public string nrTelefon { get; set; }
        
        public Client(string nume, string nrTelefon)  
        {
            this.nume = nume;
            this.nrTelefon = nrTelefon;
        }

        public Client()
        {
            nume = "";
            nrTelefon = "";
            
        }

        public override string ToString()
        {
          
            return string.Format("Client {0} {1} {2}", Id, nume, nrTelefon);



        }
        
    }
}