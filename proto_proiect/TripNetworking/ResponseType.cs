using System;

namespace TripNetworking
{
    [Serializable]
    public enum ResponseType
    {
        OK,
        ERROR,
        GET_TRIPS,
        GET_TRIPS_FILTERED,
        UPDATE,
    }
}