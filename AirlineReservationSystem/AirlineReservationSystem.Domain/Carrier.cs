using System;
using System.Collections.Generic;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public class Carrier
    {
        public string Name { get; set; }
        public string Country { get; set; }
        //public List<Crew> CrewList { get; set; }
        //public List<Flight> FlightList { get; set; }

        public Carrier(string name, string country)//, List<Crew> crew, List<Flight> flight
        {
            Name = name;
            Country = country;
            //CrewList = crew;
            //FlightList = flight;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}