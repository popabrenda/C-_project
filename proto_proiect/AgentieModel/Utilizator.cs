using System;

namespace AgentieModel;

[Serializable]
public class Utilizator : Entity<int>
{
    public string username { get; set; }
    public string password { get; set; }

        
    public Utilizator( string username, string password)  
    {
        this.username = username;
        this.password = password;
    }
    public Utilizator()
    {
        username = "";
        password = "";
    }
    public override string ToString()
    {
        return string.Format("Utilizator {0} {1} {2}", Id, username, password);
    }
}