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
    public class FlightDAL : DAL
    {
        private CarrierDAL carrierDAL = new CarrierDAL();

        public void InsertNewFlight(Flight flight)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            byte[] seatPriceByte = SerializeHelper.SerializeToByteArray(flight.Price);
            byte[] availSeatByte = SerializeHelper.SerializeToByteArray(flight.AvailableSeat);
            string sql = string.Format("Insert Into [dbo].[Flight]" +
                "(FlightNumber, DepartureDate, ArrivalDate, Origin, Destination, CarrierName, SeatPrice, AvailableSeat) Values" +
                "('{0}', DATEADD(minute, DATEDIFF(minute, 0, '{1}'), 0), DATEADD(minute, DATEDIFF(minute, 0, '{2}'), 0), '{3}', '{4}', '{5}', @seatPrice, @availSeat)",
                flight.FlightNumber, flight.DepartureTime, flight.ArrivalTime, flight.Origin, flight.Destination, flight.FlightCarrier.Name);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@seatPrice", SqlDbType.VarBinary, -1).Value = seatPriceByte;
                command.Parameters.Add("@availSeat", SqlDbType.VarBinary, -1).Value = availSeatByte;
                command.ExecuteNonQuery();
            }
        }

        public List<Flight> GetFlightList()
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<Flight>();
            string sql = "Select * From [dbo].[Flight]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["CarrierName"]);
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public List<Flight> GetFlightListFromCarrier(Carrier carrier)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<Flight>();
            string sql = string.Format("Select * From [dbo].[Flight] where CarrierName = '{0}'", carrier.Name);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Flight flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public List<Flight> GetFlightListFromCarrierName(string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<Flight>();
            string sql = string.Format("Select * From [dbo].[Flight] where CarrierName = '{0}'", carrierName);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Flight flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    
                    flightList.Add(new Flight(carrierDAL.SearchCarrierByName(carrierName), (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public List<string> GetOriginList()
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<string>();
            string sql = "Select distinct Origin From [dbo].[Flight]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flightList.Add((string)dr["Origin"]);
                }
                dr.Close();
            }
            return flightList;
        }

        public List<string> GetDestinationList()
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<string>();
            string sql = "Select distinct Destination From [dbo].[Flight]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flightList.Add((string)dr["Destination"]);
                }
                dr.Close();
            }
            return flightList;
        }

        public List<Flight> GetFlightListFromOrigin(string origin)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<Flight>();
            string sql = string.Format("Select * From [dbo].[Flight] where Origin = '{0}'", origin);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Flight flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public List<Flight> GetFlightListFromDestination(string destination)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var flightList = new List<Flight>();
            string sql = string.Format("Select * From [dbo].[Flight] where Destination = '{0}'", destination);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Flight flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }
        
        public void DeleteFlights(Flight flight)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[Flight]" +
                "where FlightNumber = '{0}'",flight.FlightNumber);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void UpdateFlight(Flight flight, string flightNo)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            byte[] priceByte = SerializeHelper.SerializeToByteArray(flight.Price);
            byte[] seatByte = SerializeHelper.SerializeToByteArray(flight.AvailableSeat);

            string sql = string.Format("Update [dbo].[Flight]"+
                "set FlightNumber='{0}', DepartureDate='{1}', ArrivalDate='{2}', Origin='{3}', Destination='{4}', " +
                "CarrierName='{5}', SeatPrice=@seatPrice, availableSeat=@availSeat "+
                "where FlightNumber = '{6}'", flight.FlightNumber, flight.DepartureTime, flight.ArrivalTime, flight.Origin,
                flight.Destination, flight.FlightCarrier.Name, flightNo);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@seatPrice", SqlDbType.VarBinary, -1).Value = priceByte;
                command.Parameters.Add("@availSeat", SqlDbType.VarBinary, -1).Value = seatByte;
                command.ExecuteNonQuery();
            }
        }

        public void UpdateAvailableSeat(Flight flight)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            byte[] seatByte = SerializeHelper.SerializeToByteArray(flight.AvailableSeat);

            string sql = string.Format("Update [dbo].[Flight]" +
                "set availableSeat = @availSeat " +
                "where FlightNumber = '{0}'", flight.FlightNumber);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@availSeat", SqlDbType.VarBinary, -1).Value = seatByte;
                command.ExecuteNonQuery();
            }
        }

        public Flight SearchFlightByFlightNumber(string flightNumber)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}'", flightNumber);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);
                    
                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndCarrier(string flightNumber, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and CarrierName='{1}'", flightNumber, carrierName);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndOrigin(string flightNumber, string origin)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Origin='{1}'", flightNumber, origin);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndOriginAndDestination(string flightNumber, string origin, string destination)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Origin='{1}' and Destination='{2}'", flightNumber, origin, destination);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndOriginAndDestinationAndCarrierName(string flightNumber, string origin, string destination, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Origin='{1}' and Destination='{2}' and CarrierName='{3}'", flightNumber, origin, destination, carrierName);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndOriginAndCarrierName(string flightNumber, string origin, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Origin='{1}' and CarrierName='{2}'", flightNumber, origin, carrierName);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndDestination(string flightNumber, string destination)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Destination='{1}'", flightNumber, destination);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByFlightNumberAndDestinationAndCarrierName(string flightNumber, string destination, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where FlightNumber='{0}' and Destination='{1}' and CarrierName='{2}'", flightNumber, destination, carrierName);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByOriginAndDestination(string origin, string destination)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where Origin='{0}' and Destination='{1}'", origin, destination);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public Flight SearchFlightByOriginAndDestinationAndCarrierName(string origin, string destination, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where Origin='{0}' and Destination='{1}' and CarrierName='{2}'", origin, destination, carrierName);
            Flight flight = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    flight = new Flight();
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flight = new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat);

                    break;
                }
                dr.Close();
            }
            return flight;
        }

        public List<Flight> SearchFlightByOriginAndCarrierName(string origin, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where Origin='{0}' and CarrierName='{1}'", origin, carrierName);
            List<Flight> flightList = new List<Flight>();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public List<Flight> SearchFlightByDestinationAndCarrierName(string destination, string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Flight] where Destination='{0}' and CarrierName='{1}'", destination, carrierName);
            List<Flight> flightList = new List<Flight>();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    byte[] dictPriceByteArr = (byte[])dr["SeatPrice"];
                    Dictionary<string, double> dictPrice = SerializeHelper.Deserialize<Dictionary<string, double>>(dictPriceByteArr);
                    byte[] dictSeatByteArr = (byte[])dr["AvailableSeat"];
                    Dictionary<string, int> dictSeat = SerializeHelper.Deserialize<Dictionary<string, int>>(dictSeatByteArr);
                    Carrier carrier = carrierDAL.SearchCarrierByName((string)dr["carrierName"]);

                    flightList.Add(new Flight(carrier, (string)dr["FlightNumber"], (string)dr["Origin"], (string)dr["Destination"],
                        (DateTime)dr["DepartureDate"], (DateTime)dr["ArrivalDate"], dictPrice, dictSeat));
                }
                dr.Close();
            }
            return flightList;
        }

        public int GetTotalFlights(string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            int sum = 0;
            string sql = string.Format("Select count(*) AS sum From [dbo].[Flight] where CarrierName = '{0}'", carrierName);
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


    }
}
