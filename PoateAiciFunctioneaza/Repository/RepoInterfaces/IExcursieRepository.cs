using PoateAiciFunctioneaza.Domain;

namespace PoateAiciFunctioneaza.Repository
{
    
public interface IExcursieRepository:IRepository<int, Excursie>
{
    void  UpdateLocuriDisponibile(int id, int nrBilete);
}
}
