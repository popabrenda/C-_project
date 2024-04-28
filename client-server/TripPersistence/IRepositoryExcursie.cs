using System;
using System.Collections.Generic;
using TripModel;


namespace TripPersistence
{

    public interface IRepositoryExcursie : IRepository<int, Excursie>
    {
        List<Excursie> FindExcursieByFilter(string obiectivTuristic, TimeSpan deLa, TimeSpan panaLa);
    }
}