using PayrollSystem.Models;

namespace PayrollSystem.Abstractions
{
    public interface IPayrollService
    {
        Salary CalculatePay(string countryCode, double hoursWorked, double hourlyRate);
    }
}
