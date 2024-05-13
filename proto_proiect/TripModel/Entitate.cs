using System;

namespace TripModel
{

    [Serializable]
    public class Entitate<TID>
    {
        public TID Id { get; set; }

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
            Entitate<TID> entitate = (Entitate<TID>)obj;
            return Id.Equals(entitate.Id);
        }
    }
}