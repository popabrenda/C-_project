using System;

namespace AgentieModel;

[Serializable]
public class Rezervare : Entity<int>
{
    public Client client { get; set; }
    public Excursie excursie { get; set; }
    public int nrBilete { get; set; }
  
        
    public Rezervare(Client client, Excursie excursie, int nrBilete) 
    {
        this.client = client;
        this.excursie = excursie;
        this.nrBilete = nrBilete;
    }
    public Rezervare()
    {
        client = new Client();
        excursie = new Excursie();
        nrBilete = 0;
    }
    public override string ToString()
    {
        return string.Format("Rezervare {0} {1} {2} {3}", Id, client, excursie, nrBilete);
    }

    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        Rezervare rezervare = (Rezervare)obj;
        return Id.Equals(rezervare.Id);
    }
    
}