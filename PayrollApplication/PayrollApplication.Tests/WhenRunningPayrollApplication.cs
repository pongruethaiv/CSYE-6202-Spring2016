using System;
using NUnit.Framework;
using PayrollApplication;

namespace PayrollApplication.Tests
{
    [TestFixture]
    public class WhenRunningPayrollApplication
    {
        SalariedEmployee salariedEmp;
        HourlyEmployee hourlyEmp;
        CommissionEmployee commissionEmp;
        SalaryBasedCommissionEmployee salaryBasedComEmp;

        #region UserEnteredValidName Tests

        [Test]
        public void When_UserEnteredValidName_ValidNameEntered_ResultShouldBeTrue()
        {
            var expected = true;

            var actual = Program.UserEnteredValidName("David James");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("John DoEEEEEE");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("first last");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("NaMe NaMe");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidName_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidName(null);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidName_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidName(" ");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidName_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidName("");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidName_InValidNameEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidName("David R. James Jr.");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("  ");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("firstlast");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidName("NaMe_NaMe$@");
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region UserEnteredValidSsn Tests

        [Test]
        public void When_UserEnteredValidSsn_ValidSsnEntered_ResultShouldBeTrue()
        {
            var expected = true;

            var actual = Program.UserEnteredValidSsn("123-45-6789");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidSsn("111-11-1111");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidSsn_InvalidSsnEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidSsn("111-11-1111-223");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidSsn("000112222");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidSsn_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidSsn("");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidSsn_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidSsn(" ");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidSsn_NullValueEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidSsn(null);

            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region UserEnteredValidAmount Tests

        [Test]
        public void When_UserEnteredValidAmount_ValidAmountEntered_ResultShouldBeTrue()
        {
            // prepare
            var expected = true;

            // action
            var actual = Program.UserEnteredValidAmount("0");
            // assert
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("0.23");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("1000.00");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("56.0324");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidAmount_NegativeNumberEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidAmount("-100");

            // assert
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("-.2299");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("-0.891");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidAmount_NullValueEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidAmount(null);

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidAmount_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidAmount(" ");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidAmount_EmptyStringEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidAmount("");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidAmount_InvalidAmountEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidAmount("salary");

            // assert
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("1000S");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidAmount("This is ten.");
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region UserEnteredValidCommission Tests

        [Test]
        public void When_UserEnteredValidCommission_ValidCommissionEntered_ResultShouldBeTrue()
        {
            var expected = true;

            var actual = Program.UserEnteredValidCommission("0.50");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidCommission("0");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_NullValueEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission(" ");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidCommission("   ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission("");

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_NegativeValueEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission("-0.4");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidCommission("-1");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_GreaterThanOneCommissionRateEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission("5");
            Assert.That(expected, Is.EqualTo(actual));

            Program.UserEnteredValidCommission("1.01");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidCommission_InvalidCommissionRateEntered_ResultShouldBeFalse()
        {
            var expected = false;

            var actual = Program.UserEnteredValidCommission("0.2p");
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region CalculateEarning Tests

        [Test]
        public void When_CalculateEarning_SalariedEmployeeIsSelected_ResultShouldBeSalary()
        {
            // prepare
            var expected = 1000.00;
            var weeklySalary = 1000.00;
            salariedEmp = new SalariedEmployee("John Smith", "111-22-3333", weeklySalary);

            // action
            var actual = salariedEmp.CalculateEarning();

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_CalculateEarning_HourlyEmployeeIsSelected_HourOfWorkLessThanOrEqual40_ResultShouldBeHourlyWageTimesHoursOfWork()
        {
            var expected = 4020.00;
            var hourlyWage = 100.50;
            var hourOfWork = 40.00;
            hourlyEmp = new HourlyEmployee("John Smith", "111-22-3333", hourlyWage, hourOfWork);

            var actual = hourlyEmp.CalculateEarning();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_CalculateEarning_HourlyEmployeeIsSelected_HourOfWorkExceed40_ResultShouldBeHourlyWageTimesHoursOfWorkPlusOT()
        {
            var expected = 5500.00;
            var hourlyWage = 100.00;
            var hourOfWork = 50.00;
            hourlyEmp = new HourlyEmployee("John Smith", "111-22-3333", hourlyWage, hourOfWork);

            var actual = hourlyEmp.CalculateEarning();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_CalculateEarning_CommissionEmployeeIsSelected_ResultShouldBeGrossSaleTimesCommissionRate()
        {
            var expected = 2777.61;
            var grossSale = 5555.22;
            var commissionRate = 0.5;
            commissionEmp = new CommissionEmployee("John Smith", "111-22-3333", grossSale, commissionRate);

            var actual = commissionEmp.CalculateEarning();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_CalculateEarning_SalaryBasedCommissionEmployeeIsSelected_ResultShouldBeGrossSaleTimesCommissionRatePlusSalary()
        {
            var expected = 3777.61;
            var grossSale = 5555.22;
            var commissionRate = 0.5;
            var weeklySalary = 1000;

            salaryBasedComEmp = new SalaryBasedCommissionEmployee("John Smith", "111-22-3333", grossSale, commissionRate, weeklySalary);

            var actual = salaryBasedComEmp.CalculateEarning();

            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region UserEnteredValidEmployeeType Tests

        [Test]
        public void When_UserEnteredValidEmployeeType_ValidEmployeeTypeEntered_ResultShouldBeTrue()
        {
            // prepare
            var expected = true;

            // action
            var actual = Program.UserEnteredValidEmployeeType("1");

            // assert
            Assert.That(expected, Is.EqualTo(actual));

            // action
            actual = Program.UserEnteredValidEmployeeType("2");

            // assert
            Assert.That(expected, Is.EqualTo(actual));

            // action
            actual = Program.UserEnteredValidEmployeeType("3");

            // assert
            Assert.That(expected, Is.EqualTo(actual));

            // action
            actual = Program.UserEnteredValidEmployeeType("4");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidEmployeeType_NullValueEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidEmployeeType(null);

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidEmployeeType_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidEmployeeType(" ");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidEmployeeType_EmptyStringEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidEmployeeType("");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnteredValidEmployeeType_InvalidEmployeeTypeEntered_ResultShouldBeFalse()
        {
            // prepare
            var expected = false;

            // action
            var actual = Program.UserEnteredValidEmployeeType("5");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion

        #region EmployeeTypeMapper Tests

        [Test]
        public void When_EmployeeTypeMapper_1IsEntered_ResultShouldBeSalariedEmployee()
        {
            // prepare
            var expected = Program.EmployeeType.SalariedEmployee;

            // action
            var actual = Program.EmployeeTypeMapper("1");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_EmployeeTypeMapper_2IsEntered_ResultShouldBeHourlyEmployee()
        {
            // prepare
            var expected = Program.EmployeeType.HourlyEmployee;

            // action
            var actual = Program.EmployeeTypeMapper("2");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_EmployeeTypeMapper_3IsEntered_ResultShouldBeCommissionEmployee()
        {
            // prepare
            var expected = Program.EmployeeType.CommissionEmployee;

            // action
            var actual = Program.EmployeeTypeMapper("3");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_EmployeeTypeMapper_4IsEntered_ResultShouldBeSalaryBasedCommissionEmployee()
        {
            // prepare
            var expected = Program.EmployeeType.SalaryBasedCommissionEmployee;

            // action
            var actual = Program.EmployeeTypeMapper("4");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_EmployeeTypeMapper_InvalidStringIsEntered_ResultShouldBeNone()
        {
            // prepare
            var expected = Program.EmployeeType.None;

            // action
            var actual = Program.EmployeeTypeMapper("5");

            // assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        #endregion
    }
}
