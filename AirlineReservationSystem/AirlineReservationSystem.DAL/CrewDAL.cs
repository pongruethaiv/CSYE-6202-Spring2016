using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.DAL
{
    public class CrewDAL : DAL
    {
        public void InsertCrew(Crew crew)
        {
            //check if crew duplicate by passport and eprsonType
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Insert Into [dbo].[Crew]" +
                "(PersonId, CarrierName) Values" +
                "('{0}', '{1}')", crew.PersonId, crew.FlightCarrier.Name);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<Crew> getCrewListFromCarrier(Carrier carrier)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Person] JOIN [dbo].[Crew]" +
                "ON ([dbo].[Person].PersonId = [dbo].[Crew].PersonId)" +
                "where [dbo].[Crew].CarrierName='{0}'", carrier.Name);
            List<Crew> crewList = new List<Crew>();
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
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType, carrier);
                    p.PersonId = (int)dr["PersonId"];
                    crewList.Add((Crew)p);
                }
                dr.Close();
            }
            return crewList;
        }

        public List<Crew> getCrewList()
        {
            CarrierDAL carrierDAL = new CarrierDAL();
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Person] JOIN [dbo].[Crew]" +
                "ON ([dbo].[Person].PersonId = [dbo].[Crew].PersonId)");
            List<Crew> crewList = new List<Crew>();
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
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType, carrierDAL.SearchCarrierByName((string)dr["CarrierName"]));
                    p.PersonId = (int)dr["PersonId"];
                    crewList.Add((Crew)p);
                }
                dr.Close();
            }
            return crewList;
        }

        public Crew SearchCrewFromPersonId(int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select p.*, c.CarrierName From [dbo].[Person] AS p INNER JOIN [dbo].[Crew] c " +
                "ON (p.PersonId = c.PersonId) " +
                "where c.PersonId='{0}'", personId);
            Person p= null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                CarrierDAL carrierDAL = new CarrierDAL();
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

                    p = new Crew( (string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType,
                        carrierDAL.SearchCarrierByName((string)dr["CarrierName"]));
                    p.PersonId = (int)dr["PersonId"];
                    break;
                }
                dr.Close();
            }
            return (Crew)p;
        }

        public Crew SearchCrewFromPassportNo(string passport)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select p.*, c.CarrierName From [dbo].[Person] AS p INNER JOIN [dbo].[Crew] c " +
                "ON (p.PersonId = c.PersonId) " +
                "where p.PassportNumber='{0}' and p.PersonType='Crew'", passport);
            Person p = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                CarrierDAL carrierDAL = new CarrierDAL();
                while (dr.Read())
                {
                    p = new Crew((string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], PersonType.Crew,
                        carrierDAL.SearchCarrierByName((string)dr["CarrierName"]));
                    p.PersonId = (int)dr["PersonId"];
                    break;
                }
                dr.Close();
            }
            return (Crew)p;
        }

        public void UpdateCrew(string carrierName, int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Update [dbo].[Crew]" +
                "set CarrierName = '{0}'" +
                "where PersonId = '{1}'", carrierName, personId);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public int GetTotalCrews(string carrierName)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            int sum = 0;
            string sql = string.Format("Select count(*) AS sum From [dbo].[Crew] where CarrierName = '{0}'", carrierName);
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
