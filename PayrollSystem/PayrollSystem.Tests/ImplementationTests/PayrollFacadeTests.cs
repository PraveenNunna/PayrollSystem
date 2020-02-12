using System;
using NUnit.Framework;
using PayrollSystem.Abstractions;
using PayrollSystem.Implementations;

namespace PayrollSystem.Tests.ImplementationTests
{
    [TestFixture]
    class PayrollFacadeTests
    {
        private IPayrollFacade _payrollFacade;
        [SetUp]
        public void Setup()
        {
            _payrollFacade = new PayrollFacade();
        }

        [TestCase("DEU", typeof(GermanyPayrollCalculator))]
        [TestCase("ESP", typeof(SpainPayrollCalculator))]
        [TestCase("ITA", typeof(ItalyPayrollCalculator))]
        [TestCase("UNW", typeof(UnsupportedCountryPayrollCalculator))]
        public void Test(string countryCode, Type type)
        {
            IPayrollCalulator service = _payrollFacade.GetCountryPayrollCalculation(countryCode);

            Assert.AreEqual(service.GetType(), type);
        }
    }
}
