using NUnit.Framework;
using PayrollSystem.Implementations;

namespace PayrollSystem.Tests.ImplementationTests
{
    [TestFixture]
    class ItalyPayrollCalculatorTests
    {
        [TestCase(20, 10, 131.62)]
        [TestCase(40, 15, 394.86)]
        [TestCase(40, 20, 526.48)]
        [TestCase(20, 20.5, 269.82)]
        [TestCase(35.5, 19.5, 455.57)]
        public void ItalyCalculateSalary_MustReturn_ValidModel(double HoursWorked, double HourlyRate, double netSalary)
        {
            var service = new ItalyPayrollCalculator();

            var salary = service.CalculateSalary(HoursWorked, HourlyRate);

            Assert.AreEqual(netSalary, salary.NetSalary);
        }
    }
}
