using TripModel;
using Utils;

namespace TripPersistence
{
    public interface IRepositoryUtilizator : IRepository<int, Utilizator>
    {
        Optional<Utilizator> FindUtilizatorByUsername(string username);
    }
}