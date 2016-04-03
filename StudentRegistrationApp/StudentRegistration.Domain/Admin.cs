using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Domain
{
    public class Admin : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Admin(string firstName, string lastName, string username, string password): base(firstName, lastName)
        {
            Username = username;
            Password = password;
        }
    }
}
