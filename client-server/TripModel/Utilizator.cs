using System;

namespace TripModel
{
    [Serializable]
    public class Utilizator : Entitate<int>
    {
        public string Nume { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Utilizator(string nume, string username, string password)
        {
            this.Nume = nume;
            this.Username = username;
            this.Password = password;
        }
    
        public override string ToString()
        {
            return "Utilizator{" +
                   "id=" + Id +
                   ", nume='" + Nume + '\'' +
                   ", username='" + Username + '\'' +
                   ", password='" + Password + '\'' +
                   '}';
        }
    
        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Utilizator utilizator = (Utilizator) obj;
            return Id == utilizator.Id;
        }
    
    }
}