using System;
using System.Linq;
using Mailer.Dto;
using Mailer.Logic.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.Logic.Implementation
{
    public class DepartmentsProvider : IDepartmentsProvider
    {
        private readonly IServiceProvider _serviceProvider;
        public DepartmentsProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IDepartments Departments(Parcel parcel)
        {
            IDepartments selectedDepartment = null;
            var departments = _serviceProvider.GetServices<IDepartments>().ToList();

            if (!departments.Any())
            {
                throw new Exception("Department not found");
            }

            foreach (var department in departments)
            {
                if (parcel.Weight > department.WeightMin && parcel.Weight < department.WeightMax)
                {
                    selectedDepartment = department;
                    break;
                }


                if (parcel.Weight > department.WeightMin && department.WeightMax == null)
                {
                    selectedDepartment = department;
                    break;
                }

                if (parcel.Value > department.Value && department.WeightMax == null && department.WeightMin == null)
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