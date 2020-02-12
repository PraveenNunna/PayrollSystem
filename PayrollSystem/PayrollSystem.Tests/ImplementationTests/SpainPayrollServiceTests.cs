using NUnit.Framework;
using PayrollSystem.Implementations;

namespace PayrollSystem.Tests.ImplementationTests
{
    [TestFixture]
    class SpainPayrollCalculatorTests
    {
        [TestCase(20, 10, 128)]
        [TestCase(40, 15, 383)]
        [TestCase(40, 20, 479)]
        [TestCase(20, 20.5, 262.40)]
        [TestCase(35.5, 19.5, 427.28)]
        public void SpainCalculateSalary_MustReturn_ValidModel(double HoursWorked, double HourlyRate, double netSalary)
        {
            var service = new SpainPayrollCalculator();

            var salary = service.CalculateSalary(HoursWorked, HourlyRate);

            Assert.AreEqual(netSalary, salary.NetSalary);
        }
    }
}
