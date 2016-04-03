using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Domain
{
    public static class StudentHelper
    {
        static Random rnd = new Random();

        public static string RandomID()
        {
            //Random rnd = new Random();
            int first = rnd.Next(0, 1000);
            int second = rnd.Next(0, 100);
            int third = rnd.Next(0, 10000);
            string id = first.ToString("D3") + "-" + second.ToString("D2") + "-" + third.ToString("D4");
            return id;
        }

        public static string RandomFirstName()
        {
            string[] first = { "Jodi", "Lemuel", "Eleanor", "Allegra", "Catharine", "Sherilyn", "Flor", "Patsy",
                "Ivy", "Mandie", "Herminia", "Giuseppina", "Eldridge", "Tatum", "Virgie", "Marry", "Deidra",
                "Sharyn","Delana", "Meredith", "Mervin", "Gena", "Venetta", "Thresa", "Lashonda", "Noe",
                "Merrie", "Oneida", "Joelle", "Reva" };
            //Random rnd = new Random();
            int r = rnd.Next(0, 30);
            return first[r];
        }

        public static string RandomLastName()
        {
            string[] last = { "Smith","Johnson","Williams","Brown","Jones","Miller","Davis","Garcia","Rodriguez",
                "Wilson","Martinez","Anderson","Taylor","Thomas","Hernandez","Moore","Martin","Jackson","Thompson",
                "White","Lopez","Lee","Gonzalez","Harris","Clark","Lewis","Robinson","Walker","Perez","Hall" };
            //Random rnd = new Random();
            int r = rnd.Next(last.Length);
            return last[r];
        }

        public static string RandomDepartment()
        {
            string[] departments = {"Information Systems", "International Affairs", "Nursing", "Pharmacy",
                "Professional Studies", "Psychology", "Public Administration"};
            //Random rnd = new Random();
            int r = rnd.Next(departments.Length);
            return departments[r];
        }

        public static string RandomEnrollmentType()
        {
            string[] enrollType = { "Full Time", "Part Time" };
            //Random rnd = new Random();
            int r = rnd.Next(enrollType.Length);
            return enrollType[r];
        }
    }
}
