using System;
using System.Linq;
using Mailer.Dto;
using Mailer.Logic.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Logic.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IServiceProvider _serviceProvider;

        public DepartmentService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDepartments GetDepartment(Parcel parcel)
        {
            IDepartments selectedDepartment = null;
            var departments = _serviceProvider.GetServices<IDepartments>().ToList();

            if (!departments.Any())
            {
                throw new Exception("Department not found");
            }

            foreach (var department in departments)
            {
                if (parcel.Weight > department.MinmumWeight && parcel.Weight < department.MaximumWeight)
                {
                    selectedDepartment = department;
                    break;
                }


                if (parcel.Weight > department.MinmumWeight && department.MaximumWeight == null)
                {
                    selectedDepartment = department;
                    break;
                }

                if (department.MaximumWeight == null && department.MinmumWeight == null)
                {
                    selectedDepartment = department;
                    break;
                }
            }

            if (selectedDepartment == null)
            {
                throw new Exception("Department not found");
            }

            return selectedDepartment;
        }
    }
}