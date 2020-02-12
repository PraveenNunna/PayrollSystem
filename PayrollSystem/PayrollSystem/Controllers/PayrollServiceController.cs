using System;
using System.Web.Http;
using PayrollSystem.Abstractions;

namespace PayrollSystem.Controllers
{
    [RoutePrefix("api/payrollservice")]
    public class PayrollServiceController : ApiController
    {
        private IPayrollService _payrollService;

        public PayrollServiceController(IPayrollService payrollService)
        {
            this._payrollService = payrollService;
        }

        /// <summary>
        /// This is a test description.
        /// </summary>
        /// <param name="countryCode">Supported country codes are DEU,SPN, ITL.</param>
        /// <param name="hoursWorked">Work Hours</param>
        /// <param name="hourlyRate">Pay per hour</param>
        /// <returns>Salary model with Tax deductions, Gross salary and Net salary.</returns>
        [Route("{countryCode}")]
        public IHttpActionResult Get(string countryCode, double hoursWorked, double hourlyRate)
        {
            if (string.IsNullOrEmpty(countryCode) || string.IsNullOrEmpty(countryCode))
            {
                BadRequest("Country code cannot be empty");
            }

            if (hoursWorked < 0)
                BadRequest("Please provide valid Work Hours");

            if (hourlyRate < 0)
                BadRequest("Please provide valid Hourly rate");

            try
            {
                var model = _payrollService.CalculatePay(countryCode, hoursWorked, hourlyRate);

                return Ok(new { success = true, salary = model });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}