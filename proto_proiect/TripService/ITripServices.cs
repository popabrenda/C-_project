using System;
using System.Collections.Generic;
using TripModel;
using Utils;

namespace TripService
{
    public interface ITripServices
    {
        Optional<Utilizator> LoginUser(string username, string password, ITripObserver client) ;
        void LogOut(string username) ;
        List<ExcursieDTO> GetAllExcursii();
        List<ExcursieDTO> GetExcursiiByFilter(String obiectiv, TimeSpan deLa, TimeSpan panaLa) ;
        void RezervaBilete(int excursieID, String numeClient, String telefonClient, int numarBilete) ;

    }
}