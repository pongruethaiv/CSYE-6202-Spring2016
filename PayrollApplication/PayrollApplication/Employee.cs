using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PayrollApplication
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Ssn { get; set; }

        public Employee(string name, string ssn)
        {
            Name = name;
            Ssn = ssn;
        }
        
        public abstract double CalculateEarning();
        
        public override string ToString()
        {
            return String.Format("{0}\nSocial security number: {1}", Name, Ssn);
        }
        
    }
}
