using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class SalariedEmployee : Employee
    {
        public double WeeklySalary { get; set; }

        public SalariedEmployee(string name, string ssn, double weeklySalary) : base(name, ssn)
        {
            WeeklySalary = weeklySalary;
        }

        public override double CalculateEarning()
        {
            return WeeklySalary;
        }

        public override string ToString()
        {
            return String.Format("Salaried employee: {0}\nWeekly salary: ${1:N2}", base.ToString(), WeeklySalary);
        }
    }
}
