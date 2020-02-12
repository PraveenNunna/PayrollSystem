using PayrollSystem.Abstractions;

namespace PayrollSystem.Implementations
{
    public class PayrollFacade : IPayrollFacade
    {
        public IPayrollCalulator GetCountryPayrollCalculation(string CountryCode)
        {
            if (CountryCode == "DEU")
            {
                return new GermanyPayrollCalculator();
            }
            else if (CountryCode == "ESP")
            {
                return new SpainPayrollCalculator();
            }
            else if (CountryCode == "ITA")
            {
                return new ItalyPayrollCalculator();
            }

            return new UnsupportedCountryPayrollCalculator();
        }
    }
}