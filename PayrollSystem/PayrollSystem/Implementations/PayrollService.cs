using PayrollSystem.Abstractions;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    public class PayrollService :IPayrollService
    {
        private readonly IPayrollFacade _payrollFacade;

        public PayrollService(IPayrollFacade payrollFacade)
        {
            this._payrollFacade = payrollFacade;
        }

        public Salary CalculatePay(string countryCode, double hoursWorked, double hourlyRate)
        {
            if (string.IsNullOrEmpty(countryCode))
            {
                throw new System.ArgumentException("message", nameof(countryCode));
            }

            if (hoursWorked < 0)
                throw new System.ArgumentException("Please provide valid Work Hours", nameof(hoursWorked));

            if (hourlyRate < 0)
                throw new System.ArgumentException("Please provide valid Hourly rate", nameof(hoursWorked));

            countryCode = countryCode.ToUpper();
            var service = _payrollFacade.GetCountryPayrollCalculation(countryCode);
            return service.CalculateSalary(hoursWorked, hourlyRate);
        }
    }
}