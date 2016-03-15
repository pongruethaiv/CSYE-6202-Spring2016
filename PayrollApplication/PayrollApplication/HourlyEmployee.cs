using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class HourlyEmployee : Employee
    {
        public double HourlyWage { get; set; }
        public double HourOfWork { get; set; }

        public HourlyEmployee(string name, string ssn, double hourlyWage, double hourOfWork) : base(name, ssn)
        {
            HourlyWage = hourlyWage;
            HourOfWork = hourOfWork;
        }

        public override double CalculateEarning()
        {
            if (HourOfWork <= 40)
            {
                return HourlyWage * HourOfWork;
            }
            else
            {
                double ot = (HourOfWork - 40) * (1.5 * HourlyWage);
                double earning = (HourlyWage * 40) + ot;
                return earning;
            }
        }

        public override string ToString()
        {
            return String.Format("Hourly employee: {0}\nHourly wage: ${1:N2}; Hour worked: {2:N2}", base.ToString(), HourlyWage, HourOfWork);
        }
    }
}
