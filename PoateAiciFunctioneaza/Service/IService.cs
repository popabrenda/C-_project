using System;
using System.Collections.Generic;
using PoateAiciFunctioneaza.Domain;

namespace PoateAiciFunctioneaza.Service
{
    public interface IService
    {
        Boolean validateUsername(String usename, String password);
        IEnumerable<Excursie> filterExcursii(String obiectiv, int oraPlecare1, int oraPlecare2);
        void addRezervare(Client client, Excursie excursie, int nrBilete);
        Excursie FindExcursie(int id);
        Client FindClient(string nume, string nrTelefon);
        IEnumerable<Excursie> getAllExcursii();
        IEnumerable<Client> getAllClienti();
    }
}