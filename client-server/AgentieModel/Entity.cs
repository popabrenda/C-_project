using System;

namespace AgentieModel
{

    [Serializable]
    public class Entity<ID> 
    {
        public ID Id { get; set; }
        public override string ToString()
        {
            return "Entitate{" +
                   "id=" + Id +
                   '}';
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Entity<ID> entitate = (Entity<ID>)obj;
            return Id.Equals(entitate.Id);
        }
    }
}