namespace PoateAiciFunctioneaza.Domain
{
    public class Utilizator: Entity<int>
    {
        public string username { get; set; }
        public string password { get; set; }
        public int Id { get; set; }
        
        public Utilizator(int id, string username, string password)  
        {
            this.Id = id;
            this.username = username;
            this.password = password;
        }
        
        public override string ToString()
        {
            return string.Format("Utilizator {0} {1} {2}", Id, username, password);
        }
    }
    
}