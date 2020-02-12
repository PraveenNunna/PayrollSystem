namespace PayrollSystem.Abstractions
{
    public interface IPayrollFacade
    {
        IPayrollCalulator GetCountryPayrollCalculation(string CountryCode);
    }
}
