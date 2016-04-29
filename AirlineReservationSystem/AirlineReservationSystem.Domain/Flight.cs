using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public class Flight
    {
        public Carrier FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        //public List<Ticket> Booking { get; set; }
        //public List<Crew> CrewList { get; set; }
        //public List<Passenger> PassengerList { get; set; }
        public Dictionary<string, double> Price { get; set; }
        public Dictionary<string, int> AvailableSeat { get; set; }

        public Flight()
        {

        }

        public Flight(Carrier carrier, string flightNo, string origin, string destination, DateTime departureTime,
            DateTime arrivalTime, Dictionary<string, double> price, Dictionary<string, int> seat)
        {
            FlightCarrier = carrier;
            FlightNumber = flightNo;
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            //Booking = booking;
            //CrewList = crew;
            //PassengerList = passenger;
            Price = price;
            AvailableSeat = seat;
        }
    }
}
