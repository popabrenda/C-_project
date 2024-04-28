using System;
using System.Collections;
using System.Collections.Generic;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Repository;

namespace PoateAiciFunctioneaza.Service
{
    public class Service:IService
    {
        private IClientRepository clientRepository;
        private IExcursieRepository excursieRepository;
        private IRezervareRepository rezervareRepository;
        private IUtilizatorReposiroty utilizatorReposiroty;

        public Service(IClientRepository clientRepository, IExcursieRepository excursieRepository,
            IRezervareRepository rezervareRepository, IUtilizatorReposiroty utilizatorReposiroty)
        {
            this.clientRepository = clientRepository;
            this.excursieRepository = excursieRepository;
            this.rezervareRepository = rezervareRepository;
            this.utilizatorReposiroty = utilizatorReposiroty;
        }

        public Boolean validateUsername(String username, String password)
        {
            IEnumerable<Utilizator> utilizatori = utilizatorReposiroty.GetAll();
            foreach (Utilizator utilizator in utilizatori)
            {
                if (utilizator.username.Equals(username) && utilizator.password.Equals(password))
                {
                     return true;
                }
                   
            }

            return false;
        }

        public IEnumerable<Excursie> filterExcursii(String obiectiv, int oraPlecare1, int oraPlecare2)
        {
            IEnumerable<Excursie> excusii = excursieRepository.GetAll();
            List<Excursie> excursieList = new List<Excursie>();
            if (oraPlecare1 > oraPlecare2)
            {
                int aux = oraPlecare1;
                oraPlecare1 = oraPlecare2;
                oraPlecare2 = aux;
            }

            foreach (Excursie excursie in excusii)
            {
                if (excursie.obiectiv.Equals(obiectiv) && excursie.oraPlecare >= oraPlecare1 &&
                    excursie.oraPlecare <= oraPlecare2)
                    excursieList.Add(excursie);
            }

            return excursieList;
        }
        public void addRezervare(Client client, Excursie excursie, int nrBilete)
        {
            if(excursie.locuriDisponibile >= nrBilete)
            {
                rezervareRepository.Add(new Rezervare(client, excursie, nrBilete));
                excursieRepository.UpdateLocuriDisponibile(excursie.Id,nrBilete);
            }else throw new Exception("Nu sunt suficiente locuri disponibile");
           
        }
        public Excursie FindExcursie(int id)
        {
            return excursieRepository.Find(id);
        }
        
        public Client FindClient(string nume, string nrTelefon)
        {
            IEnumerable<Client> clienti = clientRepository.GetAll();
            foreach (Client client in clienti)
            {
                if (client.nume.Equals(nume) && client.nrTelefon.Equals(nrTelefon))
                    return client;
            }

            return null;
        }
        public IEnumerable<Excursie> getAllExcursii()
        {
            return excursieRepository.GetAll();
        }
        public IEnumerable<Client> getAllClienti()
        {
            return clientRepository.GetAll();
        }
        
    }
}

