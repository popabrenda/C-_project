using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TripModel;
using TripPersistence;
using TripService;
using Utils;

namespace TripServer
{
    public class TripServices : ITripServices
    {
        private IRepositoryUtilizator _repositoryUtilizator;
        private IRepositoryRezervare _repositoryRezervare;
        private IRepositoryExcursie _repositoryExcursie;
        private IRepositoryFirmaTransport _repositoryFirmaTransport;
        private Dictionary<string, ITripObserver> _loggedClients;
        private readonly int defaultThreads = 5;
        private readonly object _lock = new object();
        
        public TripServices(IRepositoryUtilizator repositoryUtilizator, IRepositoryFirmaTransport repositoryFirmaTransport, IRepositoryExcursie repositoryExcursie, IRepositoryRezervare repositoryRezervare)
        {
            this._repositoryUtilizator = repositoryUtilizator;
            this._repositoryExcursie = repositoryExcursie;
            this._repositoryFirmaTransport = repositoryFirmaTransport;
            this._repositoryRezervare = repositoryRezervare;
            _loggedClients = new Dictionary<string, ITripObserver>();
        }
        
        
        public Optional<Utilizator> LoginUser(string username, string password, ITripObserver client)
        {
            Console.WriteLine("TripsServices - LoginUser" + username +" "+ password);
            lock (_lock)
            {
                var utilizatorOpt = _repositoryUtilizator.FindUtilizatorByUsername(username);
                if (utilizatorOpt.HasValue)
                {
                    var utilizator = utilizatorOpt.Value;
                    var parolaDB = utilizator.Password;
                    Console.WriteLine("TRIP SERVICES LoginUser || Parola din baza de date: " + parolaDB);
                    //var parolaDecriptata = Decrypt(parolaDB, Environment.GetEnvironmentVariable("SECRETKEY"));
                    //Console.WriteLine("TRIP SERVICES || PAROLA DECRIPTATA" + parolaDecriptata);
                    if (!parolaDB.Equals(password))
                    {
                        throw new AppException("Parola incorecta");
                    }
                    else if (_loggedClients.ContainsKey(username))
                    {
                        throw new AppException("Utilizator logat deja");
                    }
                    else
                    {
                        _loggedClients[username] = client;
                        return Optional<Utilizator>.Of(utilizator);
                    }
                }

                return Optional<Utilizator>.Empty();
            }
        }

        public void LogOut(string username)
        {
            lock (_lock)
            {
                _loggedClients.Remove(username);
            }
        }
        
        public List<ExcursieDTO> GetAllExcursii()
        {
            return _repositoryExcursie
                .FindAll()
                .Select(excursie => new ExcursieDTO(
                    excursie.Id,
                    excursie.ObiectivTuristic,
                    excursie.FirmaTransport.Nume,
                    excursie.OraPlecarii,
                    excursie.Pret,
                    excursie.NumarLocuriTotale - _repositoryRezervare.GetNumarOcupate(excursie.Id)))
                .ToList();
        }


       public List<ExcursieDTO> GetExcursiiByFilter(string obiectiv, TimeSpan deLa, TimeSpan panaLa)
       {
           lock (_repositoryExcursie)
           {
               return _repositoryExcursie
                   .FindExcursieByFilter(obiectiv, deLa, panaLa)
                   .Select(excursie => new ExcursieDTO(
                       excursie.Id,
                       excursie.ObiectivTuristic,
                       excursie.FirmaTransport.Nume,
                       excursie.OraPlecarii,
                       excursie.Pret,
                       excursie.NumarLocuriTotale - _repositoryRezervare.GetNumarOcupate(excursie.Id)))
                   .ToList();
           }
       }


        
        public void RezervaBilete(int idExcursie, string numeClient, string telefonClient, int numarBilete)
        {
            var excursie = _repositoryExcursie.FindOne(idExcursie).Value;
            var numarLocuriOcupate = _repositoryRezervare.GetNumarOcupate(idExcursie);
            if (excursie.NumarLocuriTotale - numarLocuriOcupate < numarBilete)
            {
                throw new AppException("Nu sunt suficiente locuri disponibile");
            }
            _repositoryRezervare.Save(new Rezervare(numeClient, telefonClient, excursie, numarBilete));
            NotifyAllClients();
        }
        
        private void NotifyAllClients()
        {
            Console.WriteLine("Notifying all clients ...");
            foreach (var client in _loggedClients.Values)
            {
                Task.Run(() => client.ReservationUpdate());
            }
        }
        
    }
}