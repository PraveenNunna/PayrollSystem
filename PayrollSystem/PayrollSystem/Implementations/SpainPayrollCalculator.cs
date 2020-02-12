using System;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    internal class SpainPayrollCalculator : AbstractPayrollCalulator
    {
        public SpainPayrollCalculator()
        {
            this.isProgressiveIncomeTax = true;
            this.baseTaxThreshold = 600;
            this.baseTaxPercentage = 0.25;
            this.progressiveTaxPercentage = 0.40;
        }

        public override Salary CalculateSalary(double HoursWorked, double HourlyRate)
        {
            var pensionPercentage = 0.04;

            double grossSalary = CalculateGrossPay(HoursWorked, HourlyRate);

            var incomeTax = this.CalculateIncomeTax(grossSalary);

            var socialCharge = this.CalculateSocialCharge(grossSalary);

            var pensionContribution = grossSalary * pensionPercentage;

            double totalTaxDeduction = incomeTax + socialCharge + pensionContribution;

            return new Salary()
            {
                CountryCode = "ESP",
                GrossSalary = grossSalary,
                NetSalary = Math.Round((grossSalary - totalTaxDeduction), 2),
                TaxDeductions = Math.Round(totalTaxDeduction, 2)
            };
        }

        //TODO: refactor this to extract a general progressive tax calc.
        private double CalculateSocialCharge(double grossSalary)
        {
            var baseTaxPercentage = 0.07;
            var baseTaxThreshold = 500;
            var progressiveTaxPercentage = 0.08;

            if (grossSalary > baseTaxThreshold)
            {
                var baseTaxAmount = baseTaxThreshold * baseTaxPercentage;

                var additionalTaxAmount = (grossSalary - baseTaxThreshold) * progressiveTaxPercentage;

                return baseTaxAmount + additionalTaxAmount;
            }
            else
            {
                return grossSalary * baseTaxPercentage;
            }
        }
    }
}