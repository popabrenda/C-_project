using System;

namespace TripNetworking.DTO
{
    [Serializable]
    public class FilterDTO
    {
        public string ObiectivTuristic { get; set; }
        public TimeSpan DeLa { get; set; }
        public TimeSpan PanaLa { get; set; }
        
        public FilterDTO(string obiectivTuristic, TimeSpan deLa, TimeSpan panaLa)
        {
            ObiectivTuristic = obiectivTuristic;
            DeLa = deLa;
            PanaLa = panaLa;
        }
    }
}