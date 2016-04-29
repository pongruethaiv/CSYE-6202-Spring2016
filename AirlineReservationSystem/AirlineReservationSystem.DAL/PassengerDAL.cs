using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.DAL
{
    public class PassengerDAL : DAL
    {
        public void InsertPassenger(Passenger passenger)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Insert Into [dbo].[Passenger]" +
                "(PersonId, FrequentFlyer) Values" +
                "('{0}', '{1}')", passenger.PersonId, passenger.FrequentFlyer);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public Passenger SearchPassengerFromPersonId(int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Person] AS p INNER JOIN [dbo].[Passenger] c " +
                "ON (p.PersonId = c.PersonId) " +
                "where c.PersonId='{0}'", personId);
            Passenger p = null;
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

                    p = new Passenger((string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType,
                        (string)dr["FrequentFlyer"]);
                    p.PersonId = (int)dr["PersonId"];
                    break;
                }
                dr.Close();
            }
            return p;
        }
    }
}
