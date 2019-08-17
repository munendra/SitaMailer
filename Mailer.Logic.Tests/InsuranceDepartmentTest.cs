using Mailer.Logic.Implementation;
using Xunit;

namespace Mailer.Logic.Tests
{
    public class InsuranceDepartmentTest
    {
        private readonly InsuranceDepartment _insuranceDepartment;
        public InsuranceDepartmentTest()
        {
            _insuranceDepartment = new InsuranceDepartment();
        }

        [Fact]
        public void InsuranceDepartment_Insured_ShouldSetPIsInsuredToTrueIfParcelPriceIsAbove1000()
        {

        }
    }
}