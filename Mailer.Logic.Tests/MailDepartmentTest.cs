using System;
using Mailer.Dto;
using Mailer.Logic.Implementation;
using Mailer.Logic.Interface;
using Moq;
using Xunit;

namespace Mailer.Logic.Tests
{
    public class MailDepartmentTest
    {
        private readonly MailDepartment _mailDepartment;
        private Mock<IInsuranceDepartment> _insuranceDepartment;
        public MailDepartmentTest()
        {
            _insuranceDepartment = new Mock<IInsuranceDepartment>();
            _mailDepartment = new MailDepartment(_insuranceDepartment.Object);
        }

     
        [Fact]
        public void MailDepartment_Handle_ShouldReturnParcelWithDeliverdDepartmentNameMail()
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

            var parcelStatus = _mailDepartment.Handle(parcel);
            Assert.Equal("Mail", parcelStatus.DepartmentName);
        }
    }
}