using Mailer.DependencyMapper;
using Mailer.Dto;
using Mailer.Logic.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ParcelMailer
{
    class Program
    {
        private static readonly IFileSerializer _fileSerializer;
        private static readonly IServiceProvider _serviceProvider;
        private static readonly IDepartmentService _departmentService;

        static Program()
        {
            _serviceProvider = Mapper.Map();
            _departmentService = _serviceProvider.GetService<IDepartmentService>();
            _fileSerializer = _serviceProvider.GetService<IFileSerializer>();
        }


        static void Main()
        {
            var container = _fileSerializer.DeserializeFile<Container>($"Container_68465468.xml");
            if (!container.Parcels.Any())
            {
                Console.WriteLine("No Parcel found");
                Console.Read();
                return;
            }

            Console.WriteLine($"~~~~~Parcel Details~~~~~");

            foreach (var parcel in container.Parcels)
            {
                var department = _departmentService.GetDepartment(parcel);
                var parcelStatus = department.Handle(parcel);

                Console.WriteLine($"Sender: {parcel.Sender.Name}");
                Console.WriteLine($"Receipient: {parcel.Receipient.Name}");
                Console.WriteLine($"Weight: {parcelStatus.Parcel.Weight} Kg.");
                Console.WriteLine($"Value: {parcelStatus.Parcel.Value}$");
                var status = parcelStatus.Parcel.IsInsured ? "Yes" : "No";
                Console.WriteLine($"Has Insured: {status}");
                Console.WriteLine($"Handeled by: {parcelStatus.DepartmentName} Department");
                Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            }

            Console.Read();
        }
    }
}