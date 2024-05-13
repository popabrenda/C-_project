using System;
using System.Collections.Generic;
using Proto;
using ExcursieDTO = TripModel.ExcursieDTO;
using FilterDTO = TripNetworking.DTO.FilterDTO;
using RezervareDTO = TripNetworking.DTO.RezervareDTO;
using Utilizator = TripModel.Utilizator;

namespace TripNetworking.protobuffprotocol
{
    public class ProtoUtils
    {
        public static Utilizator GetUtilizator(Proto.Request request)
        {
            var user = new Utilizator("", request.Utilizator.Username, request.Utilizator.Password);
            return user;
        }

        public static Proto.Response CreateOkResponse()
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok};
            return response;
        }
        
        public static Proto.Response CreateOkResponse(Utilizator utilizator)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Ok};
            Proto.Utilizator protoUtilizator = new Proto.Utilizator {Username = utilizator.Username, Password = utilizator.Password};
            response.Utilizator = protoUtilizator;
            return response;
        }

        public static Proto.Response CreateErrorResponse(string text)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Error, Error = text};
            return response;
        }

        public static Proto.Response CreateUpdateResponse()
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.Update};
            return response;
        }

        public static Proto.Response CreateGetTripsResponse(List<ExcursieDTO> excursii)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.GetTrips };
            foreach(var excursie in excursii)
            {
                Proto.ExcursieDTO protoExcursie = new Proto.ExcursieDTO
                {
                    Id = excursie.Id,
                    ObiectivTuristic = excursie.ObiectivTuristic,
                    FirmaTransport = excursie.FirmaTransport,
                    OraPlecarii = excursie.OraPlecarii.ToString(),
                    Pret = excursie.Pret,
                    NumarLocuriDisponibile = excursie.NumarLocuriDisponibile
                };
                response.Excursii.Add(protoExcursie);
            }

            return response;
        }
        
        public static Proto.Response CreateGetTripsFilteredResponse(List<ExcursieDTO> excursii)
        {
            Proto.Response response = new Proto.Response { Type = Proto.Response.Types.ReponseType.GetTripsFiltered };
            foreach(var excursie in excursii)
            {
                Proto.ExcursieDTO protoExcursie = new Proto.ExcursieDTO
                {
                    Id = excursie.Id,
                    ObiectivTuristic = excursie.ObiectivTuristic,
                    FirmaTransport = excursie.FirmaTransport,
                    OraPlecarii = excursie.OraPlecarii.ToString(),
                    Pret = excursie.Pret,
                    NumarLocuriDisponibile = excursie.NumarLocuriDisponibile
                };
                response.Excursii.Add(protoExcursie);
            }

            return response;
        }

        public static RezervareDTO GetRezervareDto(Proto.Request request)
        {
            var rezervare = request.Rezervare;
            return new RezervareDTO(rezervare.NumeClient, rezervare.TelefonClient, rezervare.Username,
                rezervare.NumarLocuri);
        }

        public static FilterDTO GetFilterDto(Proto.Request request)
        {
            var filtru = request.Filter;
            return new FilterDTO(filtru.ObiectivTuristic, TimeSpan.Parse(filtru.DeLa), TimeSpan.Parse(filtru.PanaLa));
        }
        
    }
}