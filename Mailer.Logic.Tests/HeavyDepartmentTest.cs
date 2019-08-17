using Mailer.Dto;
using Mailer.Logic.Implementation;
using Mailer.Logic.Interface;
using Moq;
using Xunit;

namespace Mailer.Logic.Tests
{
    public class HeavyDepartmentTest
    {
        private readonly HeavyDepartment _mailDepartment;
        private readonly Mock<IInsuranceDepartment> _insuranceDepartment;

        public HeavyDepartmentTest()
        {
            _insuranceDepartment = new Mock<IInsuranceDepartment>();
            _mailDepartment = new HeavyDepartment(_insuranceDepartment.Object);
        }

        [Fact]
        public void HeavyDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameHeavy()
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
                Weight = 12
            };

            var parcelStatus = _mailDepartment.Handle(parcel);
            Assert.Equal("Heavy", parcelStatus.DepartmentName);
        }
    }
}