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
    public class PersonDAL : DAL
    {
        public int InsertPerson(Person p)
        {
            int id;
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = "Insert Into [dbo].[Person]" +
                "(PassportNumber, FirstName, LastName, Gender, DateOfBirth, Nationality, PersonType) Values " +
                "(@passport, @first, @last, @gender, DATEADD(minute, DATEDIFF(minute, 0, @dob), 0), @nation, @personType); " +
                "SELECT @@Identity";
            //p.PassportNo, p.FirstName,p.LastName,p.Gender,p.DateOfBirth,p.Nationality, p.PersonType);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@passport", SqlDbType.NVarChar).Value =  p.PassportNo;
                command.Parameters.Add("@first", SqlDbType.NVarChar).Value = p.FirstName;
                command.Parameters.Add("@last", SqlDbType.NVarChar).Value = p.LastName;
                command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = p.Gender;
                command.Parameters.Add("@dob", SqlDbType.DateTime).Value = p.DateOfBirth;
                command.Parameters.Add("@nation", SqlDbType.NVarChar).Value = p.Nationality;
                command.Parameters.Add("@personType", SqlDbType.NVarChar).Value = p.PersonType;
                id = Convert.ToInt32(command.ExecuteScalar());
                //command.ExecuteNonQuery();
            }
            return id;
        }

        public Person SearchPersonById(int personId)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[Person] where PersonId='{0}'", personId);
            Person p=null;
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

                    p = new Person( (string)dr["FirstName"], (string)dr["LastName"], (string)dr["PassportNumber"],
                        (string)dr["Gender"], Convert.ToDateTime(dr["DateOfBirth"]), (string)dr["Nationality"], pType);
                    p.PersonId = (int)dr["PersonId"];
                    break;
                }
                dr.Close();
            }
            return p;
        }

        public void DeletePerson(Person p)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Delete from [dbo].[Person]" +
                "where PersonId = '{0}'", p.PersonId);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void UpdatePerson(Person p)
        {
            //personType
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Update [dbo].[Person] " +
                "set PassportNumber='{0}', FirstName ='{1}', LastName ='{2}', Gender ='{3}', DateOfBirth='{4}', " +
                "Nationality ='{5}' where PersonId = '{6}'", p.PassportNo, p.FirstName, p.LastName, 
                p.Gender, p.DateOfBirth, p.Nationality, p.PersonId);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
