using PayrollSystem.Models;

namespace PayrollSystem.Abstractions
{
    public interface IPayrollCalulator
    {
        Salary CalculateSalary(double HoursWorked, double HourlyRate);
    }
}
