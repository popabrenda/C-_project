using System;
using System.Collections.Generic;
using System.Configuration;
using log4net.Config;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Repository;
using Problema6_mpp.Repository;
using log4net;
using log4net.Config;

namespace PoateAiciFunctioneaza
{
    
        internal class Program
        {
            public static void Main(string[] args)
            {
                XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
                Console.WriteLine("Configuration Settings for tasksDB {0}",GetConnectionStringByName("tasksDB"));
                
                
                LogManager.GetLogger("LOG VERIF").Info("merge?");
                IDictionary<String, string> props = new SortedList<String, String>();
                
                props.Add("ConnectionString", GetConnectionStringByName("tasksDB"));
                
                UtilizatorDBRepository utilizatorDbRepository = new UtilizatorDBRepository(props);
                ClientDBRepository clientDbRepository = new ClientDBRepository(props);
                ExcursieDBRepository excursieDbRepository = new ExcursieDBRepository(props);
                RezervareDBRepository rezervareDbRepository = new RezervareDBRepository(props);
        
               Client c3 = new Client(6,"Maria", "9561651");
               clientDbRepository.Add(c3);
               Excursie e1 = new Excursie(6, "Belgia", "firma3", 21, 2140, 25);
               excursieDbRepository.Add(e1);
               Rezervare r1 = new Rezervare(6, c3, e1, 14);
               rezervareDbRepository.Add(r1);
               //utilizatorDbRepository.Add(new Utilizator(3,"username2", "password2"));
               IEnumerable<Client> clienti = clientDbRepository.GetAll();
               foreach (Client c in clienti)
               {
                   Console.WriteLine(c);
               }

               IEnumerable<Excursie> excursii = excursieDbRepository.GetAll();
               foreach (Excursie e in excursii)
               {
                   Console.WriteLine(e);
                   
               }

               
            }

            static string GetConnectionStringByName(string name)
            {
                // Assume failure.
                string returnValue = null;

                // Look for the name in the connectionStrings section.
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

                // If found, return the connection string.
                if (settings != null)
                    returnValue = settings.ConnectionString;

                return returnValue;
            }
        }
    
}