using System;
using System.IO;
using TripNetworking.Utils;
using TripPersistence;
using TripService;

namespace TripServer
{
    public class StartRPCServer
    {
        private static int defaultPort = 55555;
        private static string defaultServer = "localhost";

        public static void Main(string[] args)
        {
            string dbUrl;
            using (StreamReader reader = new StreamReader("../../db.properties"))
            {
                dbUrl = reader.ReadLine();
            }

            int portCitit = defaultPort;
            string serverCitit = defaultServer;
            using (StreamReader reader = new StreamReader("../../server.properties"))
            {
                portCitit = int.Parse(reader.ReadLine());
                serverCitit = reader.ReadLine();
                // portCitit = reader.ReadLine()
            }

            dbUrl = "Data Source=" + dbUrl;
            var db = new UtilsDB(dbUrl);
            IRepositoryUtilizator repositoryUtilizator = new RepositoryUtilizator(db);
            IRepositoryFirmaTransport repositoryFirmaTransport = new RepositoryFirmaTransport(db);
            IRepositoryExcursie repositoryExcursie = new RepositoryExcursie(db, repositoryFirmaTransport);
            IRepositoryRezervare repositoryRezervare = new RepositoryRezervare(db, repositoryExcursie);
            ITripServices serverServices = new TripServices(repositoryUtilizator, repositoryFirmaTransport,
                repositoryExcursie, repositoryRezervare);
            AbstractServer server = new RPCConcurrentServer(serverCitit, portCitit, serverServices);
            Console.WriteLine("Server started ... on port: " + portCitit);
            try
            {
                server.Start();
                Console.WriteLine("Server stopped");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            // finally
            // {
            //     server.Stop()
            // }
            // ServiceUtilizator serviceUtilizator = new ServiceUtilizator(repositoryUtilizator);
            // ServiceApplication serviceApplication = new ServiceApplication(repositoryFirmaTransport, repositoryExcursie, repositoryRezervare);
        }
    }
}