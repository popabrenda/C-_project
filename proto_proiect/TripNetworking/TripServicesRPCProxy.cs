using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using TripModel;
using TripNetworking.DTO;
using TripService;
using Utils;

namespace TripNetworking
{
    public class TripServicesRPCProxy : ITripServices
    {
        private string host;
        private int port;
        private ITripObserver client;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool finished;
        private BlockingCollection<Response> queueResponses;
        
        public TripServicesRPCProxy(string host, int port)
        {
            this.host = host;
            this.port = port;
            queueResponses = new BlockingCollection<Response>();
        }

        private void InitializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                StartReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
        private void StartReader()
        {
            Thread tw = new Thread(Run);
            tw.Start();
        }

        public virtual void Run()
        {
            while (!finished)
            {
                try
                {
                    if (stream.CanRead && stream.DataAvailable)
                    {
                        // Console.WriteLine(stream);
                        // object raspuns = formatter.Deserialize(stream);
                        // stream.Flush();
                        // stream.Position = 0L;
                        Response response = (Response)formatter.Deserialize(stream);
                        Console.WriteLine("Response received " + response);
                        if (IsUpdate(response))
                        {
                            HandleUpdate(response);
                        }
                        else
                        {
                            queueResponses.Add(response);
                        }
                    }
                    else
                    {
                        Thread.Sleep(1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    CloseConnection();
                    finished = true;
                }
            }
        }
        
        private void CloseConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                connection.Close();
                client = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }


        public Optional<Utilizator> LoginUser(string username, string password, ITripObserver client)
        {
            InitializeConnection();
            Utilizator utilizator = new Utilizator("", username, password);
            Request request = new Request.Builder().SetType(RequestType.LOGIN).SetData(utilizator).Build();
            Console.WriteLine("TRIP SERVICES RPC PROXY LOGIN USER " + utilizator + " request " + request + " client " + client);
            SendRequest(request);
            Response response = ReadResponse();
            Console.WriteLine("TRIP SERVICES RPC PROXY LOGIN USER response" + response);
            if(response.Type == ResponseType.OK)
            {
                this.client = client;
                return new Optional<Utilizator>((Utilizator) response.Data);
            }
            if(response.Type == ResponseType.ERROR)
            {
                string message = (string)response.Data;
                CloseConnection();
                throw new AppException(message);
            }
            return Optional<Utilizator>.Empty();
        }
        
        private Response ReadResponse()
        {
            Response response = null;
            try
            {
                response =queueResponses.Take();
                Console.WriteLine("Response taken from queue " + response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return response;
        }
        
        private void SendRequest(Request request)
        {
            lock (stream)
            {
                try
                {
                    formatter.Serialize(stream, request);
                    stream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        public void LogOut(string username)
        {
            Request request = new Request.Builder().SetType(RequestType.LOGOUT).SetData(username).Build();
            SendRequest(request);
            Response response = ReadResponse();
            if(response.Type == ResponseType.ERROR)
            {
                string message = (string)response.Data;
                throw new AppException(message);
            }
             this.CloseConnection();
        }

        public List<ExcursieDTO> GetAllExcursii()
        {
            Request request = new Request.Builder().SetType(RequestType.GET_TRIPS).Build();
            SendRequest(request);
            Response response = ReadResponse();
            if(response.Type == ResponseType.ERROR)
            {
                string message = (string)response.Data;
                throw new AppException(message);
            }
            return (List<ExcursieDTO>) response.Data;
        }

        public List<ExcursieDTO> GetExcursiiByFilter(string obiectiv, TimeSpan deLa, TimeSpan panaLa)
        {
            Request request = new Request.Builder().SetType(RequestType.GET_TRIPS_FILTERED).SetData(new FilterDTO(obiectiv, deLa, panaLa)).Build();
            SendRequest(request);
            Response response = ReadResponse();
            if(response.Type == ResponseType.ERROR)
            {
                string message = (string)response.Data;
                throw new AppException(message);
            }
            return (List<ExcursieDTO>) response.Data;
        }

        public void RezervaBilete(int excursieID, string numeClient, string telefonClient, int numarBilete)
        {
            RezervareDTO rezervare = new RezervareDTO(numeClient, telefonClient, excursieID, numarBilete);
            Request request = new Request.Builder().SetType(RequestType.RESERVATION).SetData(rezervare).Build();
            SendRequest(request);
            Response response = ReadResponse();
            if(response.Type == ResponseType.ERROR)
            {
                string message = (string)response.Data;
                throw new AppException(message);
            }
        }
        
        private bool IsUpdate(Response response)
        {
            return response.Type == ResponseType.UPDATE;
        }

        private void HandleUpdate(Response response)
        {
            if (response.Type == ResponseType.UPDATE)
            {
                client.ReservationUpdate();
            }
        }
    }
}