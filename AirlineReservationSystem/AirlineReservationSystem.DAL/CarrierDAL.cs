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
    public class CarrierDAL : DAL
    {
        public void InsertCarrier(Carrier carrier)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            //byte[] crewByte = ObjectExtension.SerializeToByteArray(carrier.CrewList);
            //byte[] flightByte = ObjectExtension.SerializeToByteArray(carrier.FlightList);

            string sql = string.Format("Insert Into [dbo].[Carrier]" +
                "(Name, Country) Values" +
                "('{0}', '{1}')", carrier.Name, carrier.Country);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Carrier> GetCarrierList()
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var carrierList = new List<Carrier>();
            string sql = "Select * From [dbo].[Carrier]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    //byte[] crewListByteArr = (byte[])dr["CrewList"];
                    //List<Crew> crewList = ObjectExtension.Deserialize<List<Crew>>(crewListByteArr);
                    //byte[] flightListByteArr = (byte[])dr["FlightList"];
                    //List<Flight> flightList = ObjectExtension.Deserialize<List<Flight>>(flightListByteArr);

                    carrierList.Add(new Carrier((string)dr["Name"], (string)dr["Country"]));
                }
                dr.Close();
            }
            return carrierList;
        }

        public List<string> GetCountryList()
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            var countryList = new List<string>();
            string sql = "Select distinct Country From [dbo].[Carrier]";
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    countryList.Add((string)dr["Country"]);
                }
                dr.Close();
            }
            return countryList;
        }

        public Carrier SearchCarrierByName(string name)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Carrier] where Name = '{0}'", name);
            Carrier carrier = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    //byte[] crewByteArr = (byte[])dr["CrewList"];
                    //List<Crew> crewList = ObjectExtension.Deserialize<List<Crew>>(crewByteArr);
                    //byte[] flightByteArr = (byte[])dr["FlightList"];
                    //List<Flight> flightList = ObjectExtension.Deserialize<List<Flight>>(flightByteArr);
                    carrier = new Carrier((string)dr["Name"], (string)dr["Country"]);
                    break;
                }
                dr.Close();
            }
            return carrier;
        }

        public List<Carrier> SearchCarrierListByCountry(string country)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Carrier] where Country = '{0}'", country);
            var carrierList = new List<Carrier>();
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Carrier carrier = new Carrier((string)dr["Name"], (string)dr["Country"]);
                    carrierList.Add(carrier);
                }
                dr.Close();
            }
            return carrierList;
        }

        public void DeleteCarrier(Carrier carrier)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[Carrier]" +
                "where Name = '{0}'", carrier.Name);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCarrier(Carrier carrier, string name)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Update [dbo].[Carrier] set Name = '{0}', Country = '{1}'" +
                "where Name = '{2}'", carrier.Name, carrier.Country, name);
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}
