using System;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    internal class ItalyPayrollCalculator : AbstractPayrollCalulator
    {
        public ItalyPayrollCalculator()
        {
            this.isProgressiveIncomeTax = false;
            this.baseTaxPercentage = 0.25;
        }

        public override Salary CalculateSalary(double HoursWorked, double HourlyRate)
        {
            var npsPercentage = 0.0919;

            var grossSalary = this.CalculateGrossPay(HoursWorked, HourlyRate);

            var incomeTax = this.CalculateIncomeTax(grossSalary);

            var npsContribution = grossSalary * npsPercentage;

            var taxDeduction = incomeTax + npsContribution;

            return new Salary()
            {
                CountryCode = "ITA",
                GrossSalary = grossSalary,
                NetSalary = Math.Round(grossSalary - taxDeduction, 2),
                TaxDeductions = Math.Round(taxDeduction, 2)
            };
        }
    }
}