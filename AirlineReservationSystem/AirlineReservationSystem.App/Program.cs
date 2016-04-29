using AirlineReservationSystem.DAL;
using AirlineReservationSystem.Domain;
using AirlineReservationSystem.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using G = System.Configuration;

namespace AirlineReservationSystem.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //CreateMocData();

            UpdateLogFileWhenStart();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

            UpdateLogFileWhenTerminate();
        }

        public static void CreateMocData()
        {
            Person p = new Person("Pong", "Viriyothai", "Z0000", "Female", DateTime.Now, "Thai", PersonType.Person);
            PersonDAL personDAL = new PersonDAL();
            int id = personDAL.InsertPerson(p);
            p.PersonId = id;
            User u = new User("admin", "admin", RoleType.Administrator, p);
            UserDAL userDAL = new UserDAL();
            userDAL.InsertMockUser(u);

            Person p2 = new Person("John", "Sean", "Z0001", "Male", DateTime.Now, "German", PersonType.Person);
            id = personDAL.InsertPerson(p2);
            p2.PersonId = id;
            User u2 = new User("regular", "regular", RoleType.Regular, p2);
            userDAL.InsertMockUser(u2);

            Person p3 = new Person("Ming", "Chan", "Z0002", "Male", DateTime.Now, "Chinese", PersonType.Crew);
            id = personDAL.InsertPerson(p3);
            p3.PersonId = id;
            User u3 = new User("crew", "crew", RoleType.Crew, p3);
            userDAL.InsertMockUser(u3);
        }

        public static void UpdateLogFileWhenStart()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                LogAppend.Log("Application Started", w);
            }

            using (StreamReader r = File.OpenText("log.txt"))
            {
                LogAppend.DumpLog(r);
            }
        }

        public static void UpdateLogFileWhenTerminate()
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                LogAppend.Log("Application Terminated", w);
            }

            using (StreamReader r = File.OpenText("log.txt"))
            {
                LogAppend.DumpLog(r);
            }
        }

    }

    
}
