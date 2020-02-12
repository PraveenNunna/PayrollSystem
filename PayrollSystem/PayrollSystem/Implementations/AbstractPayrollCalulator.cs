using PayrollSystem.Abstractions;
using PayrollSystem.Models;

namespace PayrollSystem.Implementations
{
    public abstract class AbstractPayrollCalulator : IPayrollCalulator
    {
        protected bool isProgressiveIncomeTax;

        protected double baseTaxThreshold;

        protected double baseTaxPercentage;

        protected double progressiveTaxPercentage;

        protected double CalculateIncomeTax(double grossSalary)
        {
            if (this.isProgressiveIncomeTax)
            {
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
            else
            {
                return grossSalary * baseTaxPercentage;
            }
        }

        protected double CalculateGrossPay(double HoursWorked, double HourlyRate)
        {
            return HoursWorked * HourlyRate;
        }

        public abstract Salary CalculateSalary(double HoursWorked, double HourlyRate);
    }
}