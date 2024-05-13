using TripModel;

namespace TripPersistence
{
    public interface IRepositoryRezervare : IRepository<int, Rezervare>
    {
        int GetNumarOcupate(int excursieId);
    }
}