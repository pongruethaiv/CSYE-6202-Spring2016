using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class SalaryBasedCommissionEmployee : CommissionEmployee
    {
        public double WeeklySalary;

        public SalaryBasedCommissionEmployee(string name, string ssn, double grossSale, double commissionRate, double weeklySalary) : base(name, ssn, grossSale, commissionRate)
        {
            WeeklySalary = weeklySalary;
        }

        public override double CalculateEarning()
        {
            return (GrossSale * CommissionRate) + WeeklySalary;
        }

        public override string ToString()
        {
            return String.Format("Base salaried {0}\nBase salary: ${1:N2}", base.ToString(), WeeklySalary);
        }
    }
}
