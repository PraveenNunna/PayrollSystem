using System;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    internal class GermanyPayrollCalculator : AbstractPayrollCalulator
    {
        public GermanyPayrollCalculator()
        {
            this.isProgressiveIncomeTax = true;
            this.baseTaxPercentage = 0.25;
            this.baseTaxThreshold = 400;
            this.progressiveTaxPercentage = 0.32;
        }

        public override Salary CalculateSalary(double HoursWorked, double HourlyRate)
        {
            var pensionPercentage = 0.02;

            double grossSalary = CalculateGrossPay(HoursWorked, HourlyRate);

            var incomeTax = this.CalculateIncomeTax(grossSalary);

            var pensionContribution = grossSalary * pensionPercentage;

            double totalTaxDeduction = incomeTax + pensionContribution;

            return new Salary()
            {
                CountryCode = "DEU",
                GrossSalary = grossSalary,
                NetSalary = Math.Round((grossSalary - totalTaxDeduction), 2),
                TaxDeductions = Math.Round(totalTaxDeduction, 2)
            };
        }
    }
}