using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    public class Passenger : Person
    {
        public string FrequentFlyer { get; set; }

        public Passenger( string first, string last, string passport, string gender, DateTime dob, string nationality, PersonType personType,
            string frequentFlyer)
            : base( first, last, passport, gender, dob, nationality, personType)
        {
            FrequentFlyer = frequentFlyer;
        }
    }
}
