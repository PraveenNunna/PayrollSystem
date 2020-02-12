using NUnit.Framework;
using PayrollSystem.Implementations;

namespace PayrollSystem.Tests.ImplementationTests
{
    [TestFixture]
    class GermanyPayrollCalculatorTests
    {
        [TestCase(20, 10, 146)]
        [TestCase(40, 15, 424)]
        [TestCase(40, 20, 556)]
        [TestCase(20, 20.5, 298.6)]
        [TestCase(35.5, 19.5, 484.88)]
        public void GermanyCalculateSalary_MustReturn_ValidModel(double HoursWorked, double HourlyRate, double netSalary)
        {
            var service = new GermanyPayrollCalculator();

            var salary = service.CalculateSalary(HoursWorked, HourlyRate);

            Assert.AreEqual(netSalary, salary.NetSalary);
        }
    }
}
