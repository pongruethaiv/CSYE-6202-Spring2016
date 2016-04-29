using System;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public class Ticket
    {
        public int TicketId;
        public Flight Flight;
        public string SeatClass;
        public double Price;
        public Passenger Passenger;

        public Ticket( Flight flight, string seatClass, double price, Passenger passenger)
        {
            Flight = flight;
            SeatClass = seatClass;
            Price = price;
            Passenger = passenger;
        }
    }
}