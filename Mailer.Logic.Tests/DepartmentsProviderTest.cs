using Mailer.DependencyMapper;
using Mailer.Dto;
using Mailer.Logic.Implementation;
using Moq;
using System;
using Xunit;

namespace Mailer.Logic.Tests
{
    public class DepartmentsProviderTest
    {
        private readonly DepartmentsProvider _departmentsProvider;

        public DepartmentsProviderTest()
        {
            var serviceProvider = Mapper.Map();
            _departmentsProvider = new DepartmentsProvider(serviceProvider);
        }


        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnMailDepartmentObjectIfWeightUp1Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 0.5;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<MailDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnRegularDepartmentObjectIfWeightUpTo10Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 5;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<RegularDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfWeightMoreThen10Kg()
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
            };
            parcel.Weight = 11;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfWeightIs20Kg()
        {
            var parcel = new Parcel();
            parcel.Weight = 20;
            parcel.Value = 0;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }

        [Fact]
        public void DepartmentProvider_Handle_ShouldReturnHeavyDepartmentObjectIfValueIs2000()
        {
            var parcel = new Parcel()
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
            };
            parcel.Weight = 20;
            parcel.Value = 2000;
            var department = _departmentsProvider.Departments(parcel);
            Assert.IsType<HeavyDepartment>(department);
        }
    }
}