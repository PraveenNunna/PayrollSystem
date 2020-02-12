namespace PayrollSystem.Models
{
    public class Salary
    {
        public string CountryCode { get; set; }

        public double GrossSalary { get; set; }

        public double TaxDeductions { get; set; }

        public double NetSalary { get; set; }
    }
}