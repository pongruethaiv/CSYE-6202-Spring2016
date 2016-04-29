using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.DAL
{
    public class UserDAL : DAL
    {
        private PersonDAL personDAL = new PersonDAL();

        public void InsertMockUser(User user)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            //byte[] personByte = ObjectExtension.SerializeToByteArray(user.Person);
            string sql = string.Format("Insert Into [dbo].[User]" +
                "(Username, Password, Role, PersonId) Values" +
                "('{0}', '{1}', '{2}', '{3}')", user.Username, user.Password, user.Role, user.Person.PersonId);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                //command.Parameters.Add("@binaryValue", SqlDbType.VarBinary, -1).Value = personByte;
                command.ExecuteNonQuery();
            }
        }

        //public List<User> GetUserList()
        //{
        //    OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
        //    var userList = new List<User>();
        //    string sql = "Select * From [dbo].[User]";
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        SqlDataReader dr = command.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            RoleType roleType;
        //            string role = (string)dr["Role"];
        //            if (role.Equals("Administrator"))
        //            {
        //                roleType = RoleType.Administrator;
        //            }
        //            else roleType = RoleType.Regular;

        //            byte[] personByteArr = (byte[])dr["Person"];
        //            Person p = ObjectExtension.Deserialize<Person>(personByteArr);

        //            userList.Add(new User((string)dr["Username"], (string)dr["Password"], roleType, p));
        //        }
        //        dr.Close();
        //    }
        //    return userList;
        //}

        public User AuthenticateUsernameAndPassword(string username, string password)
        {
            OpenConnection(GetConnectionStringFromExeConfig("ConnectionString"));
            string sql = string.Format("Select * From [dbo].[User] where Username='{0}' and Password = '{1}'", username, password);
            User user = null;
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    RoleType roleType;
                    string role = (string)dr["Role"];
                    if (role.Equals("Administrator"))
                    {
                        roleType = RoleType.Administrator;
                    }
                    else if (role.Equals("Regular"))
                    {
                        roleType = RoleType.Regular;
                    }
                    else roleType = RoleType.Crew;
                    
                    Person p = personDAL.SearchPersonById((int)dr["PersonId"]);
                    user = new User((string)dr["Username"], (string)dr["Password"], roleType, p);
                    break;
                }
                dr.Close();
            }
            return user;
        }

    }
}
