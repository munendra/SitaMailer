using Mailer.Dto;
using Mailer.Logic.Implementation;
using Mailer.Logic.Interface;
using Moq;
using Xunit;

namespace Mailer.Logic.Tests
{
    public class RegularDepartmentTest
    {
        private readonly RegularDepartment _regularDepartment;
        private readonly Mock<IInsuranceDepartment> _InsuranceDepartment;

        public RegularDepartmentTest()
        {
            _InsuranceDepartment = new Mock<IInsuranceDepartment>();
            _regularDepartment = new RegularDepartment(_InsuranceDepartment.Object);
        }

        [Fact]
        public void RegularDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameRegular()
        {
            var parcel = new Parcel
            {
                Receipient = new User()
                {
                    Name = "R. Receipient",
                    Address = new Address
                    {
                        City = "New Delhi",
                        HouseNumber = "#3",
                        PostalCode = "IN0090",
                        Street = "20"
                    }
                },
                Sender = new User()
                {
                    Name = "S. serder",
                    Address = new Address
                    {
                        City = "gurgaon",
                        HouseNumber = "388",
                        PostalCode = "IN007",
                        Street = "6"
                    }
                },
                Weight = 1
            };

            var parcelStatus = _regularDepartment.Handle(parcel);
            Assert.Equal("Regular", parcelStatus.DepartmentName);
        }
    }
}