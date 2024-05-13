using System;
using System.Collections.Concurrent;
using System.Linq;
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
    public class TripClientRPCWorker : ITripObserver
    {
        private ITripServices server;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;
        
        public TripClientRPCWorker(ITripServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void Run()
        {
            while(connected)
            {
                try
                {
                    if (stream.CanRead && stream.DataAvailable)
                    {
                        object request = formatter.Deserialize(stream);
                        object response = HandleRequest((Request)request);
                        if (response != null)
                        {
                            SendResponse((Response)response);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error "+e);
            }
        }
        
        private void SendResponse(Response response)
        {
            lock (stream)
            {
                try
                {
                    Console.WriteLine($"Send response ... {response}");
                    formatter.Serialize(stream, response);
                    stream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        
        private Response HandleRequest(Request request)
        {
            Response response = null;
            RequestType requestType = request.Type;
            switch (requestType)
            {
                case RequestType.LOGIN:
                    Console.WriteLine("Login request ...");
                    Console.WriteLine("Request data: " + request.Data);
                    Utilizator utilizator = (Utilizator) request.Data;
                    Console.WriteLine("TRIP CLIENT RPC WORKER || Utilizator: " + utilizator);
                    try
                    {
                        var userOpt = server.LoginUser(utilizator.Username, utilizator.Password, this);
                        Console.WriteLine("TRIP CLIENT RPC WORKER || userOpt: " + userOpt);
                        if (userOpt.HasValue)
                        {
                            Console.WriteLine("TRIP CLIENT RPC WORKER  if userOpt has value || userOpt.Value: " + userOpt.Value);
                            return new Response.Builder().SetType(ResponseType.OK).SetData(userOpt.Value).Build();
                        }
                        else
                        {
                            connected = false;
                            Console.WriteLine("TRIP CLIENT RPC WORKER  if userOpt has value ELSEEE || userOpt.Value: " + userOpt.Value);
                            return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid username or password").Build();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("TRIP CLIENT RPC WORKER  catch || e: " + e);
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case RequestType.LOGOUT:
                    Console.WriteLine("Logout request ...");
                    string username = (string) request.Data;
                    try
                    {
                        server.LogOut(username);
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.OK).Build();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case RequestType.GET_TRIPS:
                    Console.WriteLine("Get excursii request ...");
                    try
                    {
                        return new Response.Builder().SetType(ResponseType.GET_TRIPS).SetData(server.GetAllExcursii()).Build();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case RequestType.GET_TRIPS_FILTERED:
                    Console.WriteLine("Get excursii filtered request ...");
                    var filter = (FilterDTO) request.Data;
                    try
                    {
                        return new Response.Builder().SetType(ResponseType.GET_TRIPS_FILTERED).SetData(server.GetExcursiiByFilter(filter.ObiectivTuristic, filter.DeLa, filter.PanaLa)).Build();
                        
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case RequestType.RESERVATION:
                    Console.WriteLine("Rezerva request ...");
                    RezervareDTO rezervareDTO = (RezervareDTO) request.Data;
                    try
                    {
                        server.RezervaBilete(rezervareDTO.ExcursieID, rezervareDTO.NumeClient, rezervareDTO.TelefonClient, rezervareDTO.NumarBilete);
                        return new Response.Builder().SetType(ResponseType.OK).Build();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                default:
                    return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid request type").Build();
            }
        }
        
        


        public void ReservationUpdate()
        {
            Console.WriteLine("Reservation update ...");
            Response response = new Response.Builder().SetType(ResponseType.UPDATE).SetData(null).Build();
            SendResponse(response);
        }
    }
}