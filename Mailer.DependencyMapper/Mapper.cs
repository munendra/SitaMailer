using Mailer.Logic.Implementation;
using Mailer.Logic.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Mailer.DependencyMapper
{
    public static class Mapper
    {
        public static IServiceProvider Map()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartmentService, DepartmentService>()
                .AddScoped<IFileSerializer, XmlFileSerializer>()
                .AddScoped<IInsuranceDepartment, InsuranceDepartment>()
                .AddScoped<IDepartments, HeavyDepartment>()
                .AddScoped<IDepartments, MailDepartment>()
                .AddScoped<IDepartments, RegularDepartment>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}