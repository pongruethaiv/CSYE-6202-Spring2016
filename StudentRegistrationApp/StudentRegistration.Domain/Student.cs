using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Domain
{
    public class Student : Person
    {
        public string StudentID { get; set; }
        public string Department { get; set; }
        public string EnrollmentType { get; set; }

        public Student(string studentID, string firstName, string lastName, string department, string enrollmentType) : base(firstName, lastName)
        {
            StudentID = studentID;
            Department = department;
            EnrollmentType = enrollmentType;
        }

        public override string ToString()
        {
            return string.Format("StudentID: {0}, FirstName: {1}, LastName: {2}, Department: {3}, EnrollmentType: {4}", StudentID, FirstName, LastName, Department, EnrollmentType);
        }
    }
}
