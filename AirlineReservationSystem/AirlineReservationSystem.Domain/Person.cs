using System;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNo { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public PersonType PersonType { get; set; }

        public Person( string first, string last, string passport, string gender, DateTime dob, string nationality, PersonType personType)
        {
            //PersonId = personId;
            FirstName = first;
            LastName = last;
            PassportNo = passport;
            Gender = gender;
            DateOfBirth = dob;
            Nationality = nationality;
            PersonType = personType;
        }
    }
}