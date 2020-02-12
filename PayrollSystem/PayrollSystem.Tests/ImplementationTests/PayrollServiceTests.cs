using System;
using NUnit.Framework;
using Moq;
using PayrollSystem.Abstractions;

namespace PayrollSystem.Tests.ImplementationTests
{
    [TestFixture]
    class PayrollServiceTests
    {
        private Mock<IPayrollFacade> _payrollFacade;
        private Mock<IPayrollCalulator> _payrollCalculator;

        [SetUp]
        public void SetUp()
        {
            _payrollCalculator = new Mock<IPayrollCalulator>();
            _payrollCalculator.Setup(pc => pc.CalculateSalary(It.IsAny<double>(), It.IsAny<double>())).Returns(new Models.Salary());

            _payrollFacade = new Mock<IPayrollFacade>();
            _payrollFacade.Setup(pf => pf.GetCountryPayrollCalculation(It.IsAny<string>())).Returns(_payrollCalculator.Object);
        }

        [Test]
        public void CalculatePay_ThrowsException_WhenCountryCodeIsNull()
        {
            var payrollService = new Implementations.PayrollService(_payrollFacade.Object);

            Assert.Throws<ArgumentException>(() => payrollService.CalculatePay("", 0.0, 0.0));
        }

        [Test]
        public void CalculatePay_ThrowsException_WhenWorkHoursIsInvalid()
        {
            var payrollService = new Implementations.PayrollService(_payrollFacade.Object);

            Assert.Throws<ArgumentException>(() => payrollService.CalculatePay("Code", -1, 1.0));
        }

        [Test]
        public void CalculatePay_GivesValidModel_WhenProvidedValidData()
        {
            var service = new Implementations.PayrollService(_payrollFacade.Object);

            var model = service.CalculatePay("Code", 1.0, 1.0);

            Assert.IsNotNull(model);
        }

        // Integtation tests.
    }
}
