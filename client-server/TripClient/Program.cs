using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripNetworking;
using TripService;

namespace TripClient
{
    static class Program
    {
        private static int defaultPort = 55555;
        private static string defaultServer = "localhost";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int portCitit = defaultPort;
            string serverCitit = defaultServer;
            using (StreamReader reader = new StreamReader("../../client.properties"))
            {
                portCitit = int.Parse(reader.ReadLine());
                serverCitit = reader.ReadLine();
                // portCitit = reader.ReadLine()
            }
            ITripServices server = new TripServicesRPCProxy(serverCitit, portCitit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView(server));
        }
    }
}