using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication
{
    public class CommissionEmployee : Employee
    {
        public double GrossSale { get; set; }
        public double CommissionRate { get; set; }

        public CommissionEmployee(string name, string ssn, double grossSale, double commissionRate) : base(name, ssn)
        {
            GrossSale = grossSale;
            CommissionRate = commissionRate;
        }

        public override double CalculateEarning()
        {
            return GrossSale * CommissionRate;
        }

        public override string ToString()
        {
            return String.Format("Commission employee: {0}\nGross sales: ${1:N2}\nCommission rate: {2:N2}", base.ToString(), GrossSale, CommissionRate);
        }
    }
}
