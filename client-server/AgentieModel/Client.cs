using System;

namespace AgentieModel;

[Serializable]
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
    
    public override bool Equals(object? obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        Client client = (Client)obj;
        return Id.Equals(client.Id);
    }
        
}