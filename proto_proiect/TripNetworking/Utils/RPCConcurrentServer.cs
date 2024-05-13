using System;
using System.Net.Sockets;
using System.Threading;
using TripService;

namespace TripNetworking.Utils
{
    public class RPCConcurrentServer : AbstractConcurrentServer
    {
        private ITripServices server;
        private TripClientRPCWorker worker;
        public RPCConcurrentServer(string host, int port, ITripServices server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("RPCConcurrentServer...");
        }
        protected override Thread CreateWorker(TcpClient client)
        {
            worker = new TripClientRPCWorker(server, client);
            return new Thread(new ThreadStart(worker.Run));
        }

    }
}