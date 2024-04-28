using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Repository;
using PoateAiciFunctioneaza.Service;
using Problema6_mpp.Repository;

namespace WindowsFormsAppLogIn
{
    static class Program
    {
        
        public static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
                Console.WriteLine("Configuration Settings for tasksDB {0}",GetConnectionStringByName("tasksDB"));
                
                
                IDictionary<String, string> props = new SortedList<String, String>();
                
                props.Add("ConnectionString", GetConnectionStringByName("tasksDB"));
                
                UtilizatorDBRepository utilizatorDbRepository = new UtilizatorDBRepository(props);
                ClientDBRepository clientDbRepository = new ClientDBRepository(props);
                ExcursieDBRepository excursieDbRepository = new ExcursieDBRepository(props);
                RezervareDBRepository rezervareDbRepository = new RezervareDBRepository(props);
                IService service = new Service(clientDbRepository, excursieDbRepository, rezervareDbRepository,utilizatorDbRepository);

                
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Form1(service));

                           
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
    
