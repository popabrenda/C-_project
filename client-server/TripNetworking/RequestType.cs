using System;

namespace TripNetworking
{
    [Serializable]
    public enum RequestType
    {
        LOGIN,
        LOGOUT,
        REGISTER,
        GET_TRIPS,
        GET_TRIPS_FILTERED,
        RESERVATION
    }
}