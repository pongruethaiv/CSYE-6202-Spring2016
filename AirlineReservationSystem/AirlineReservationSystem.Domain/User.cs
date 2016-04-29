using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleType Role { get; set; }
        public Person Person { get; set; }

        public User(string username, string pwd, RoleType role, Person person)
        {
            Username = username;
            Password = pwd;
            Role = role;
            Person = person;
        }
    }
}
