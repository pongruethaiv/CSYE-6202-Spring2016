using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.DAL
{
    public class FlightCrewDAL : DAL
    {
        private CarrierDAL carrierDAL = new CarrierDAL();

        public void InsertNewAssignedFlightCrew(Flight flight, int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Insert Into [dbo].[FlightAndCrew]" +
                "(FlightNumber, PersonId) Values" +
                "('{0}', '{1}')",
                flight.FlightNumber, personId);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Crew> GetAssignedCrewFromFlightNumber(string flightNo, Carrier c)
        {
            List<Crew> crewList = new List<Crew>();
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select p.* From [dbo].[Person] AS p INNER JOIN [dbo].[FlightAndCrew] AS fc " +
                "ON (p.PersonId = fc.PersonId) " +
                "where fc.FlightNumber = '{0}'", flightNo);
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

                    Person p = new Crew( (string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType, c);
                    p.PersonId = (int)dr["PersonId"];
                    crewList.Add((Crew)p);
                }
                dr.Close();
            }
            return crewList;
        }

        public int GetNoOfCrewFromFlightNumber(string flightNo)
        {
            int sum = 0;
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select count(*) as sum from [dbo].[FlightAndCrew] " +
                "where FlightNumber = '{0}'", flightNo);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    sum = Convert.ToInt32(dr["sum"]);
                }
                dr.Close();
            }
            return sum;
        }

        public int GetNoOfFlightFromCrew(int personId)
        {
            int sum = 0;
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select count(*) as sum from [dbo].[FlightAndCrew] " +
                "where PersonId = '{0}'", personId);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    sum = Convert.ToInt32(dr["sum"]);
                }
                dr.Close();
            }
            return sum;
        }

        public List<Flight> GetRosterFromCrew(Crew c)
        {
            List<Flight> roster = new List<Flight>();
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select f.* From [dbo].[Flight] AS f INNER JOIN [dbo].[FlightAndCrew] AS fc " +
                "ON (f.FlightNumber = fc.FlightNumber) " +
                "where fc.PersonId = '{0}'", c.PersonId);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["CarrierName"]);
                    byte[] priceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> price = SerializeHelper.Deserialize<Dictionary<string, double>>(priceByteArr);
                    byte[] seatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> seat = SerializeHelper.Deserialize<Dictionary<string, int>>(seatByteArr);

                    Flight flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"],
                        (string)dr["Destination"], Convert.ToDateTime(dr["DepartureDate"]),
                        Convert.ToDateTime(dr["ArrivalDate"]), price, seat);
                    roster.Add(flight);
                }
                dr.Close();
            }
            return roster;
        }

        public void DeleteFlightCrewFromFlightNumber(string oldFlightNo)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[FlightAndCrew]" +
               "where FlightNumber = '{0}'",oldFlightNo);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void DeleteFlightCrewFromPersonId(int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[FlightAndCrew]" +
               "where PersonId = '{0}'", personId);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
