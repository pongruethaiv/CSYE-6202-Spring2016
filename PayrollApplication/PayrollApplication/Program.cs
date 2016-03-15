using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PayrollApplication
{
    public class Program
    {
        public enum EmployeeType
        {
            None,
            SalariedEmployee,
            HourlyEmployee,
            CommissionEmployee,
            SalaryBasedCommissionEmployee
        }

        static void Main(string[] args)
        {

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Please select type of employee (1-4): \n1.Salaried Employee\n2.Hourly Employee\n3.Commission Employee\n4.Salary Based Commission Employee\nEnter anything else to terminate");
                string choice = Console.ReadLine();
                Console.WriteLine();
                if (UserEnteredValidEmployeeType(choice))
                {
                    EmployeeType empType = EmployeeTypeMapper(choice);
                    Console.Write("Please enter Firstname and Lastname: ");
                    string name = Console.ReadLine();
                    Console.Write("Please enter SSN (xxx-xx-xxxx): ");
                    string ssn = Console.ReadLine();

                    if (empType.Equals(EmployeeType.SalariedEmployee))
                    {
                        Console.Write("Please enter Weekly salary: ");
                        string salary = Console.ReadLine();
                        if (UserEnteredValidName(name) && UserEnteredValidSsn(ssn) && UserEnteredValidAmount(salary))
                        {
                            try
                            {
                                SalariedEmployee salariedEmp1 = new SalariedEmployee(name, ssn, double.Parse(salary));
                                Console.WriteLine(salariedEmp1.ToString());
                                Console.WriteLine("Earned: ${0:N2}\n", salariedEmp1.CalculateEarning());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input was invalid\n");
                        }
                    }

                    else if (empType.Equals(EmployeeType.HourlyEmployee))
                    {
                        Console.Write("Please enter Hourly wage: ");
                        string hourlyWage = Console.ReadLine();
                        Console.Write("Please enter Hours worked: ");
                        string hoursWorked = Console.ReadLine();
                        if (UserEnteredValidName(name) && UserEnteredValidSsn(ssn) &&
                            UserEnteredValidAmount(hourlyWage) && UserEnteredValidAmount(hoursWorked))
                        {
                            try
                            {
                                HourlyEmployee hourlyEmployee = new HourlyEmployee(name, ssn, double.Parse(hourlyWage), double.Parse(hoursWorked));
                                Console.WriteLine("\n" + hourlyEmployee.ToString());
                                Console.WriteLine("Earned: ${0:N2}\n", hourlyEmployee.CalculateEarning());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input was invalid\n");
                        }
                    }

                    else if (empType.Equals(EmployeeType.CommissionEmployee))
                    {
                        Console.Write("Please enter Gross sales: ");
                        string grossSale = Console.ReadLine();
                        Console.Write("Please enter Commission rate (Max=1): ");
                        string commissionRate = Console.ReadLine();
                        if (UserEnteredValidName(name) && UserEnteredValidSsn(ssn) &&
                            UserEnteredValidAmount(grossSale) && UserEnteredValidCommission(commissionRate))
                        {
                            try
                            {
                                CommissionEmployee commissionEmployee = new CommissionEmployee(name, ssn, double.Parse(grossSale), double.Parse(commissionRate));
                                Console.WriteLine("\n" + commissionEmployee.ToString());
                                Console.WriteLine("Earned: ${0:N2}\n", commissionEmployee.CalculateEarning());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input was invalid\n");
                        }
                    }

                    else if (empType.Equals(EmployeeType.SalaryBasedCommissionEmployee))
                    {
                        Console.Write("Please enter Gross sales: ");
                        string grossSale = Console.ReadLine();
                        Console.Write("Please enter Commission rate (Max=1): ");
                        string commissionRate = Console.ReadLine();
                        Console.Write("Please enter Base salary: ");
                        string basedSalary = Console.ReadLine();
                        if (UserEnteredValidName(name) && UserEnteredValidSsn(ssn) &&
                            UserEnteredValidAmount(grossSale) && UserEnteredValidCommission(commissionRate) &&
                            UserEnteredValidAmount(basedSalary))
                        {
                            try
                            {
                                SalaryBasedCommissionEmployee basePlusCommissionEmployee = new SalaryBasedCommissionEmployee(name, ssn, double.Parse(grossSale), double.Parse(commissionRate), double.Parse(basedSalary));
                                Console.WriteLine("\n" + basePlusCommissionEmployee.ToString());
                                Console.WriteLine("Earned: ${0:N2}\n", basePlusCommissionEmployee.CalculateEarning());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input was invalid\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Application terminated.");
                    flag = false;
                }

            } 
        }

        public static bool UserEnteredValidSsn(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (value.Trim() == "" || !Regex.IsMatch(value, @"^\d{3}-\d{2}-\d{4}$"))
            {
                return false;
            }
            else return true;
        }

        public static bool UserEnteredValidName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (value.Trim() == "" || !Regex.IsMatch(value, @"^[A-Za-z]+ [A-Za-z]+$"))
            {
                return false;
            }
            else return true;
        }

        public static bool UserEnteredValidAmount(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                else if (double.Parse(value) >= 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UserEnteredValidCommission(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                else if (double.Parse(value) >= 0 && double.Parse(value) <= 1)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UserEnteredValidEmployeeType(string userInput)
        {
            var result = false;

            if (object.ReferenceEquals(null, userInput))
            {
                result = false;
            }
            else if (userInput.Equals("1") || userInput.Equals("2") ||
                userInput.Equals("3") || userInput.Equals("4"))
            {
                result = true;
            }
            return result;
        }

        public static EmployeeType EmployeeTypeMapper(string userInput)
        {
            EmployeeType empType = EmployeeType.None;

            if (userInput.Equals("1")) empType = EmployeeType.SalariedEmployee;
            else if (userInput.Equals("2")) empType = EmployeeType.HourlyEmployee;
            else if (userInput.Equals("3")) empType = EmployeeType.CommissionEmployee;
            else if (userInput.Equals("4")) empType = EmployeeType.SalaryBasedCommissionEmployee;

            return empType;
        }
    }
}
