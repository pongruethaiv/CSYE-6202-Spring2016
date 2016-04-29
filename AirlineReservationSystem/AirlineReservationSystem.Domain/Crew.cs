using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public class Crew : Person
    {
        public Carrier FlightCarrier { get; set; }
        //public List<Flight> Roster { get; set; }

        public Crew( string first, string last, string passport, string gender, DateTime dob, string nationality, PersonType personType,
            Carrier carrier)
            : base( first, last, passport, gender, dob, nationality, personType)
        {
            FlightCarrier = carrier;
            //Roster = roster;
        }
    }
}
