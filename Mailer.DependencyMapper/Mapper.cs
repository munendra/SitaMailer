using System;
using Mailer.Logic;
using Mailer.Logic.Implementation;
using Mailer.Logic.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Mailer.DependencyMapper
{
    public static class Mapper
    {
        public static IServiceProvider Map()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IDepartmentsProvider, DepartmentsProvider>()
                .AddScoped<IDepartments, HeavyDepartment>()
                //  .AddScoped<IDepartments, InsuranceDepartment>()
                .AddScoped<IDepartments, MailDepartment>()
                .AddScoped<IDepartments, RegularDepartment>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}