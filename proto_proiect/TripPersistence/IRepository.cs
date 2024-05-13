using System.Collections.Generic;
using TripModel;
using Utils;

namespace TripPersistence
{
    public interface IRepository<ID, E> where E : Entitate<ID>
    {
        Optional<E> Save(E entitate);
        Optional<E> Update(E entitate);
        Optional<E> FindOne(ID id);
        Optional<E> Delete(ID id);
        List<E> FindAll();
    }
}