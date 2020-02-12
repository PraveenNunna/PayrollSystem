using PayrollSystem.Abstractions;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    internal class UnsupportedCountryPayrollCalculator : AbstractPayrollCalulator
    {
        public override Salary CalculateSalary(double HoursWorked, double HourlyRate)
        {
            throw new System.Exception("Provided Country not supported");
        }
    }
}