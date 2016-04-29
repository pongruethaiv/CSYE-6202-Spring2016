using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.DAL
{
    public class TicketDAL : DAL
    {
        private FlightDAL flightDAL = new FlightDAL();
        private PassengerDAL passengerDAL = new PassengerDAL();

        public int InsertTicket(Ticket ticket)
        {
            int id;
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = "Insert Into[dbo].[Ticket]" +
                "(TicketClass, Price, PersonId, FlightNumber) Values " +
                "(@ticketClass, @price, @personId, @flightNo); " +
                "SELECT @@Identity";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@ticketClass", SqlDbType.NVarChar).Value = ticket.SeatClass;
                command.Parameters.Add("@price", SqlDbType.NVarChar).Value = ticket.Price;
                command.Parameters.Add("@personId", SqlDbType.NVarChar).Value = ticket.Passenger.PersonId;
                command.Parameters.Add("@flightNo", SqlDbType.NVarChar).Value = ticket.Flight.FlightNumber;
                id = Convert.ToInt32(command.ExecuteScalar());
            }
            return id;
        }

        public void DeleteTicketUsingPersonId(Person passenger, Flight flight)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[Ticket] " +
                "where PersonId = '{0}' AND FlightNumber = '{1}'", 
                passenger.PersonId, flight.FlightNumber);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTicket(Ticket ticket)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[Ticket] " +
                "where TicketId = '{0}'",
                ticket.TicketId);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Passenger> GetPassengerFromFlightNumber(string flightNo)
        {
            List<Passenger> pList = new List<Passenger>();
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Passenger] JOIN [dbo].[Ticket] " +
                "ON ([dbo].[Passenger].PersonId = [dbo].[Ticket].PersonId) JOIN [dbo].[Person] " +
                "ON ([dbo].[Passenger].PersonId = [dbo].[Person].PersonId) " +
                "where [dbo].[Ticket].FlightNumber = '{0}'", flightNo);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string type = (string)dr["PersonType"];
                    PersonType pType;
                    if (type.Equals("Person"))
                    {
                        pType = PersonType.Person;
                    }
                    else if (type.Equals("Crew"))
                    {
                        pType = PersonType.Crew;
                    }
                    else pType = PersonType.Passenger;

                    Passenger p = new Passenger( (string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType, (string)dr["FrequentFlyer"]);
                    p.PersonId = (int)dr["PersonId"];
                    pList.Add(p);
                }
                dr.Close();
            }
            return pList;
        }

        public List<Ticket> GetTicketFromFlightNumber(string flightNo)
        {
            List<Ticket> tList = new List<Ticket>();
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Ticket] " +
                "where FlightNumber = '{0}'", flightNo);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string flightNumber = (string)dr["FlightNumber"];
                    int personId = (int)dr["PersonId"];
                    Ticket ticket = new Ticket(flightDAL.SearchFlightByFlightNumber(flightNumber),
                        (string)dr["TicketClass"], (double)dr["Price"], passengerDAL.SearchPassengerFromPersonId((int)dr["PersonId"]));
                    ticket.TicketId = (int)dr["TicketId"];
                    tList.Add(ticket);
                }
                dr.Close();
            }
            return tList;
        }

        public Ticket SearchTicketByPassenger(Passenger passenger)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("select * from [dbo].[Ticket] " +
                "where personId = '{0}'", passenger.PersonId);
            Ticket ticket = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string flightNumber = (string)dr["FlightNumber"];
                    int personId = (int)dr["PersonId"];
                    ticket = new Ticket(flightDAL.SearchFlightByFlightNumber(flightNumber),
                        (string)dr["TicketClass"], (double)dr["Price"], passenger);
                    ticket.TicketId = (int)dr["TicketId"];
                    break;
                }
                dr.Close();
            }
            return ticket;

        }

        public Ticket SearchTicketByTicketId(int ticketId)
        {
            flightDAL = new FlightDAL();
            passengerDAL = new PassengerDAL();
            Ticket ticket = null;
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("select * from [dbo].[Ticket] " +
                "where TicketId = '{0}'", Convert.ToString(ticketId));
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    string flightNumber = (string)dr["FlightNumber"];
                    int personId = (int)dr["PersonId"];
                    ticket = new Ticket(flightDAL.SearchFlightByFlightNumber(flightNumber), 
                        (string)dr["TicketClass"], (double)dr["Price"], passengerDAL.SearchPassengerFromPersonId((int)dr["PersonId"]));
                    ticket.TicketId = (int)dr["TicketId"];
                    break;
                }
                dr.Close();
            }
            return ticket;

        }
    }
}
