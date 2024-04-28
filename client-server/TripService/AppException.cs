using System;

namespace TripService
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}