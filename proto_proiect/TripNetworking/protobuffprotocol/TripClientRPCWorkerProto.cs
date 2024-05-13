using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Google.Protobuf;
using TripModel;
using TripNetworking.DTO;
using TripNetworking.protobuffprotocol;
using TripService;
using Utils;

namespace TripNetworking
{
    public class TripClientRPCWorkerProto : ITripObserver
    {
        private ITripServices server;
        private TcpClient connection;
        private NetworkStream stream;
        // private IFormatter formatter;
        private volatile bool connected;
        
        public TripClientRPCWorkerProto(ITripServices server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                // formatter = new BinaryFormatter();
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
                    Proto.Request request = Proto.Request.Parser.ParseDelimitedFrom(stream);
                    Proto.Response response = HandleRequest(request);
                    if (response != null)
                    {
                        SendResponse(response);
                    }
                    // if (stream.CanRead && stream.DataAvailable)
                    // {
                    //     object request = formatter.Deserialize(stream);
                    //     object response = HandleRequest((Request)request);
                    //     if (response != null)
                    //     {
                    //         SendResponse((Response)response);
                    //     }
                    // }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
				
                try
                {
                    Thread.Sleep(100);
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
        
        private void SendResponse(Proto.Response response)
        {
            lock (stream)
            {
                try
                {
                    Console.WriteLine($"Send response ... {response}");
                    // formatter.Serialize(stream, response);
                    response.WriteDelimitedTo(stream);
                    stream.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
        
        private Proto.Response HandleRequest(Proto.Request request)
        {
            Proto.Response response = null;
            Proto.Request.Types.RequestType requestType = request.Type;
            switch (requestType)
            {
                case Proto.Request.Types.RequestType.Login:
                    Console.WriteLine("Login request ...");

                    Utilizator utilizator = ProtoUtils.GetUtilizator(request);
                    try
                    {
                        var userOpt = server.LoginUser(utilizator.Username, utilizator.Password, this);
                        if (userOpt.HasValue)
                        {
                            return ProtoUtils.CreateOkResponse(userOpt.Value);
                            // return new Response.Builder().SetType(ResponseType.OK).SetData(userOpt.Value).Build();
                        }
                        else
                        {
                            connected = false;
                            return ProtoUtils.CreateErrorResponse("Invalid username or password");
                            // return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid username or password").Build();
                        }
                    }
                    catch (Exception e)
                    {
                        connected = false;
                        return ProtoUtils.CreateErrorResponse(e.Message);
                        // return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case Proto.Request.Types.RequestType.Logout:
                    Console.WriteLine("Logout request ...");
                    string username = request.Username;
                    try
                    {
                        server.LogOut(username);
                        connected = false;
                        return ProtoUtils.CreateOkResponse();
                        // return new Response.Builder().SetType(ResponseType.OK).Build();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return ProtoUtils.CreateErrorResponse(e.Message);
                        // return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case Proto.Request.Types.RequestType.GetTrips:
                    Console.WriteLine("Get excursii request ...");
                    try
                    {
                        return ProtoUtils.CreateGetTripsResponse(server.GetAllExcursii());
                        // return new Response.Builder().SetType(ResponseType.GET_TRIPS).SetData(server.GetAllExcursii()).Build();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return ProtoUtils.CreateErrorResponse(e.Message);
                        // return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case Proto.Request.Types.RequestType.GetTripsFiltered:
                    Console.WriteLine("Get excursii filtered request ...");
                    var filter = ProtoUtils.GetFilterDto(request);
                    try
                    {
                        return ProtoUtils.CreateGetTripsFilteredResponse(server.GetExcursiiByFilter(filter.ObiectivTuristic, filter.DeLa, filter.PanaLa));
                        // return new Response.Builder().SetType(ResponseType.GET_TRIPS_FILTERED).SetData(server.GetExcursiiByFilter(filter.ObiectivTuristic, filter.DeLa, filter.PanaLa)).Build();
                        
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return ProtoUtils.CreateErrorResponse(e.Message);
                        // return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                case Proto.Request.Types.RequestType.Reservation:
                    Console.WriteLine("Rezerva request ...");
                    RezervareDTO rezervareDTO = ProtoUtils.GetRezervareDto(request);
                    try
                    {
                        server.RezervaBilete(rezervareDTO.ExcursieID, rezervareDTO.NumeClient, rezervareDTO.TelefonClient, rezervareDTO.NumarBilete);
                        // return new Response.Builder().SetType(ResponseType.OK).Build();
                        return ProtoUtils.CreateOkResponse();
                    }
                    catch (AppException e)
                    {
                        connected = false;
                        return ProtoUtils.CreateErrorResponse(e.Message);
                        // return new Response.Builder().SetType(ResponseType.ERROR).SetData(e.Message).Build();
                    }
                default:
                    return ProtoUtils.CreateErrorResponse("Invalid request type");
                    // return new Response.Builder().SetType(ResponseType.ERROR).SetData("Invalid request type").Build();
            }
        }
        
        


        public void ReservationUpdate()
        {
            Console.WriteLine("Reservation update ...");
            Proto.Response response = ProtoUtils.CreateUpdateResponse();
            // Response response = new Response.Builder().SetType(ResponseType.UPDATE).SetData(null).Build();
            SendResponse(response);
        }
    }
}