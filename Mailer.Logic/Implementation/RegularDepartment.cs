using Mailer.Dto;
using Mailer.Logic.Interface;

namespace Mailer.Logic.Implementation
{
    public class RegularDepartment : IDepartments
    {
        public double? WeightMin { get; set; }
        public double? WeightMax { get; set; }
        public string Name { get; }
        public double Value { get; set; }

        public RegularDepartment()
        {
            WeightMin = 1;
            WeightMax = 10;
            Value = 0;
            Name = "Regular";
        }

        public ParcelStatus Handle(Parcel parcel)
        {
            return new ParcelStatus
            {
                Parcel = parcel,
                Department = Name
            };
        }
    }
}